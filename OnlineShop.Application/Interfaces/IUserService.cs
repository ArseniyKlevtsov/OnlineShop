using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.DTOs.UserDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IUserService
{
    Task<UserWithRolesResponse> GetUserWithRolesAsync(string userId, CancellationToken cancellationToken);
    Task<IEnumerable<UserWithRolesResponse>> GetAllUsersWithRolesAsync(CancellationToken cancellationToken);

    Task<UserWithRolesResponse> CreateUserAsync(CreateUserRequestDto userDto, CancellationToken cancellationToken);
    Task UpdateUserAsync(UpdateUserInfoRequestDto userDto, CancellationToken cancellationToken);
    Task DeleteUserAsync(string userId, CancellationToken cancellationToken);
}
