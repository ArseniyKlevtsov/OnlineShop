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
    public async Task<IActionResult> Register(CreateUserRequestDto createUserRequestDto)
    {
        await _authService.Register(createUserRequestDto);
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequestDto userLoginRequestDto)
    {
        var token = await _authService.Login(userLoginRequestDto);
        return Ok(new { token });
    }
}
