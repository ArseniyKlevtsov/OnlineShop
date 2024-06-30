using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.DTOs.UserDTOs.Responses;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserWithRolesResponse> GetUserWithRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {userId} not found.");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var userDto = _mapper.Map<UserWithRolesResponse>(user);
        userDto.Roles = roles.ToList();

        return userDto;
    }

    public async Task<IEnumerable<UserWithRolesResponse>> GetAllUsersWithRolesAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var userDtos = new List<UserWithRolesResponse>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var userDto = _mapper.Map<UserWithRolesResponse>(user);
            userDto.Roles = roles.ToList();
            userDtos.Add(userDto);
        }

        return userDtos;
    }

    public async Task<UserWithRolesResponse> CreateUserAsync(CreateUserRequestDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var result = await _userManager.CreateAsync(user, userDto.Password!);

        if (!result.Succeeded)
        {
            throw new ApplicationException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        await _userManager.AddToRoleAsync(user, "User");

        return await GetUserWithRolesAsync(user.Id);
    }

    public async Task UpdateUserAsync(UpdateUserInfoRequestDto userDto)
    {
        var user = await _userManager.FindByEmailAsync(userDto.Email!);
        if (user == null)
        {
            throw new NotFoundException($"User with email {userDto.Email} not found.");
        }

        _mapper.Map(userDto, user);
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new ApplicationException($"Failed to update user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    public async Task DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {userId} not found.");
        }

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            throw new ApplicationException($"Failed to delete user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}