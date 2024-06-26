using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.DTOs.UserDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IUserService
{
    Task<UserWithRolesResponse> GetUserWithRolesAsync(string userId);
    Task<IEnumerable<UserWithRolesResponse>> GetAllUsersWithRolesAsync();

    Task<UserWithRolesResponse> CreateUserAsync(CreateUserRequestDto userDto);
    Task UpdateUserAsync(UpdateUserInfoRequestDto userDto);
    Task DeleteUserAsync(string userId);
    Task<bool> AuthenticateUserAsync(UserLoginRequestDro userLoginRequestDro);
}
