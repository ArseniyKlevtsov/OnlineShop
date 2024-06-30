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
    public async Task<ActionResult<UserWithRolesResponse>> GetUser([FromRoute] string userId, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserWithRolesAsync(userId, cancellationToken);
        return Ok(user);
    }

    [HttpGet]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<ActionResult<IEnumerable<UserWithRolesResponse>>> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUsersWithRolesAsync(cancellationToken);
        return Ok(users);
    }

    [HttpPost]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<ActionResult<UserWithRolesResponse>> CreateUser([FromBody] CreateUserRequestDto createUserDto, CancellationToken cancellationToken)
    {
        var createdUser = await _userService.CreateUserAsync(createUserDto, cancellationToken);
        return CreatedAtAction(nameof(GetUser), new { userId = createdUser.Id }, createdUser);
    }

    [HttpPut]
    [Authorize(Policy = "RequireAdminOrUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserInfoRequestDto updateUserDto, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserAsync(updateUserDto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{userId}")]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<IActionResult> DeleteUser(string userId, CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(userId, cancellationToken);
        return NoContent();
    }
}