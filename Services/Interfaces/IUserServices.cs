using MetroClaim.Api.Dtos.User;

namespace MetroClaim.Api.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllUserAsync(CancellationToken cancellationToken);
    Task RegisterUserAsync(CreateUserRequestDto requestDto, CancellationToken cancellationToken);
}
