using MetroClaim.Api.Dtos.User;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MetroClaim.Api.Controllers;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUserAsync(cancellationToken);
        return Ok(new ApiResponse<IEnumerable<UserResponseDto>>(users));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(CreateUserRequestDto requestDto, CancellationToken cancellationToken)
    {
        await _userService.RegisterUserAsync(requestDto, cancellationToken);
        return Ok(new ApiResponse<object>("user registered"));
    }
}