using MetroClaim.Api.Dtos.User;
using MetroClaim.Api.Services.Interfaces;
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
        var user = await _userService.GetAllUserAsync(cancellationToken);
        if (!user.Any())
        {
            return NotFound("User Not Found");
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(CreateUserRequestDto requestDto, CancellationToken cancellationToken)
    {
        await _userService.RegisterUserAsync(requestDto, cancellationToken);
        return Ok();
    }
}
