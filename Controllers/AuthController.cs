using MetroClaim.Api.Dtos.Auth;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MetroClaim.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        await _authService.LoginAsync(requestDto, cancellationToken);
        return Ok(new ApiResponse<object>("authorized"));
    }
}