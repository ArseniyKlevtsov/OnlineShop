using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.DTOs.UserDTOs.Responses;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    [Authorize(Policy = "RequireAdminOrUser")]
    public async Task<ActionResult<UserWithRolesResponse>> GetUser(string userId)
    {
        var user = await _userService.GetUserWithRolesAsync(userId);
        return Ok(user);
    }

    [HttpGet]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<ActionResult<IEnumerable<UserWithRolesResponse>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersWithRolesAsync();
        return Ok(users);
    }

    [HttpPost]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<ActionResult<UserWithRolesResponse>> CreateUser([FromBody] CreateUserRequestDto createUserDto)
    {
        var createdUser = await _userService.CreateUserAsync(createUserDto);
        return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserName }, createdUser);
    }

    [HttpPut]
    [Authorize(Policy = "RequireAdminOrUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserInfoRequestDto updateUserDto)
    {
        await _userService.UpdateUserAsync(updateUserDto);
        return NoContent();
    }

    [HttpDelete("{userId}")]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        await _userService.DeleteUserAsync(userId);
        return NoContent();
    }
}