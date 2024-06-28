using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.Exceptions.AuthExceptions;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.Application.Servises;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> Register(CreateUserRequestDto createUserRequestDto)
    {
        var user = new User
        {
            UserName = createUserRequestDto.Email,
            Email = createUserRequestDto.Email,
            FirstName = createUserRequestDto.FirstName,
            LastName = createUserRequestDto.LastName
        };

        var result = await _userManager.CreateAsync(user, createUserRequestDto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }

        return result;
    }

    public async Task<string> Login(UserLoginRequestDto userLoginRequestDto)
    {
        var user = await _userManager.FindByNameAsync(userLoginRequestDto.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, userLoginRequestDto.Password))
        {
            throw new UserNotFoundException($"user {userLoginRequestDto.Email} was not found or the password is incorrect");
        }

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
