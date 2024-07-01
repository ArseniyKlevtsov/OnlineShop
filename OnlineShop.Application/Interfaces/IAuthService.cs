using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.DTOs.UserDTOs.Requests;

namespace OnlineShop.Application.Interfaces;

public interface IAuthService
{
    Task Register(CreateUserRequestDto createUserRequestDto);
    Task<string> Login(UserLoginRequestDto userLoginRequestDto);
}