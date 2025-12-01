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

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        // 1. Ambil User
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user is null || user.IsDeleted)
        {
            throw new NullReferenceException("User not found");
        }

        // 2. Soft Delete User
        user.IsDeleted = true;
        user.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            // Update User jadi Deleted
            await _userRepository.UpdateAsync(user);
        }, cancellationToken);
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllUserAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var activeUsers = users.Where(u => !u.IsDeleted);

        var userMap = activeUsers.Select(u => new UserResponseDto(
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

        if (!(requestDto.Password == requestDto.PasswordConfirmation))
        {
            throw new ArgumentException("registered password not match");
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

    public async Task UpdateAsync(Guid id, UpdateUserRequestDto requestDto, CancellationToken cancellationToken)
    {
        // 1. Ambil User
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null || user.IsDeleted)
        {
            throw new NullReferenceException("user not found");
        }

        // 2. Update Field
        user.Fullname = requestDto.Fullname;
        user.Email = requestDto.Email;
        user.Role = requestDto.Role;
        user.BankAccountNumber = requestDto.BankAccountNumber;
        user.ManagerId = requestDto.ManagerId;
        user.UpdatedAt = DateTime.UtcNow;

        // 3. Simpan
        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _userRepository.UpdateAsync(user);
        }, cancellationToken);
    }
}
