using MetroClaim.Api.Dtos.User;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositories;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;

namespace MetroClaim.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IUserRepository userRepository,
        IAccountRepository accountRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<UserResponseDto>> GetAllUserAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        var userMap = users.Select(u => new UserResponseDto(
            u.Id,
            u.EmployeeId!,
            u.Fullname!,
            u.Email!,
            u.Role,
            u.BankAccountNumber,
            u.ManagerId
        ));

        return userMap;
    }

    public async Task RegisterUserAsync(CreateUserRequestDto requestDto, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(requestDto.Email, cancellationToken);
        if (existingUser is not null)
        {
            throw new ArgumentException("Email already registered");
        }

        var newUserId = Guid.NewGuid();

        var newUser = new User
        {
            Id = newUserId,
            EmployeeId = requestDto.EmployeeId,
            Fullname = requestDto.Fullname,
            Email = requestDto.Email,
            Role = requestDto.Role,
            BankAccountNumber = requestDto.BankAccountNumber,
            ManagerId = requestDto.ManagerId,
        };

        var newAccount = new Account
        {
            Id = Guid.NewGuid(),
            UserId = newUserId,
            PasswordHash = requestDto.Password,
            IsActive = true,
            IsUsed = false,
        };

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _userRepository.CreateAsync(newUser, cancellationToken);
            await _accountRepository.CreateAsync(newAccount, cancellationToken);
        }, cancellationToken);
    }
}
