using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequestDto createUserRequestDto)
    {
        var result = await _authService.Register(createUserRequestDto);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto)
    {
        var token = await _authService.Login(userLoginRequestDto);

        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(new { token });
    }
}
