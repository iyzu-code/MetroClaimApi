using MetroClaim.Api.Dtos.Auth;
using MetroClaim.Api.Repositories;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;

namespace MetroClaim.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IUserRepository userRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(requestDto.Email, cancellationToken);

        if (user is null)
        {
            throw new NullReferenceException("Email atau Password salah.");
        }

        if (user.IsDeleted)
        {
            throw new ArgumentException("account deleted");
        }

        var account = await _accountRepository.GetByUserIdAsync(user.Id, cancellationToken);

        if (account is null)
        {
            throw new NullReferenceException("Email atau Password salah.");
        }

        if (account.PasswordHash != requestDto.Password)
        {
            throw new ArgumentException("Email atau Password salah.");
        }

        return $"Authorized {user.Fullname} ({user.Role})";
    }
}
