using AutoMapper;
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
    private readonly IMapper _mapper;

    public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task Register(CreateUserRequestDto createUserRequestDto)
    {
        // initialize. need be deleted
        if (!await _roleManager.RoleExistsAsync("User"))
        {
            await _roleManager.CreateAsync(new IdentityRole("User"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            var adminUser = new User
            {
                UserName = "adminBOb587@gmail.com",
                Email = "adminBOb587@gmail.com",
                FirstName = "adminBOb587",
                LastName = "adminBOb587"
            };
            await _userManager.CreateAsync(adminUser, "adminBOb587_!");
            await _userManager.AddToRoleAsync(adminUser, "Admin");

            var bobUser = new User
            {
                UserName = "bobUserBOb587@gmail.com",
                Email = "bobUserBOb587@gmail.com",
                FirstName = "bobUserBOb587",
                LastName = "bobUserBOb587"
            };
            await _userManager.CreateAsync(bobUser, "bobUserBOb587_!");
            await _userManager.AddToRoleAsync(bobUser, "User");
        }

        var user = _mapper.Map<User>(createUserRequestDto);
        user.UserName = user.Email;
        var result = await _userManager.CreateAsync(user, createUserRequestDto.Password!);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }
        else
        {
            var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new RegistrationException($"Failed to register user: {errorMessage}", new Exception());
        }
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
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        var userRoles = await _userManager.GetRolesAsync(user);
        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
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
