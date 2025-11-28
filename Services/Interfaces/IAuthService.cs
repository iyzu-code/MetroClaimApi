using MetroClaim.Api.Dtos.Auth;

namespace MetroClaim.Api.Services.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken);
}
