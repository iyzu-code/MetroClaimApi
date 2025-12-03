using System.Security.Claims;
using MetroClaim.Api.Dtos.Auth;
using MetroClaim.Api.Repositories;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;

namespace MetroClaim.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHashHandler _hashHandler;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(IUserRepository userRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork, IHashHandler hashHandler, ITokenHandler tokenHandler)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
        _hashHandler = hashHandler;
        _tokenHandler = tokenHandler;
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

        bool isPasswordValid = _hashHandler.ValidateHash(requestDto.Password, account.PasswordHash!);

        if (!isPasswordValid)
        {
            throw new ArgumentException("Email atau Password salah.");
        }

        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Name, user.Fullname ?? "no-name"));
        claims.Add(new Claim(ClaimTypes.Email, user.Email ?? "no-email"));
        claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));

        var token = _tokenHandler.Access(claims);

        return token;
    }
}
