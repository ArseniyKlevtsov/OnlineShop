using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.DTOs.UserDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IUserService
{
    Task<UserWithRolesResponse> GetUserWithRolesAsync(Guid userId);
    Task<IEnumerable<UserWithRolesResponse>> GetAllUsersWithRolesAsync();
    Task<UserWithRolesResponse> CreateUserAsync(CreateUserRequestDto userDto);
    Task UpdateUserAsync(UpdateUserRequestDto userDto);
    Task DeleteUserAsync(Guid userId);
    Task<bool> AuthenticateUserAsync(UserLoginInfoResponse loginInfo);
}
