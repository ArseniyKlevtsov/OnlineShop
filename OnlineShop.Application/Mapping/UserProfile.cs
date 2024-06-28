using AutoMapper;
using OnlineShop.Application.DTOs.UserDTOs.Requests;
using OnlineShop.Application.DTOs.UserDTOs.Responses;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserWithRolesResponse>();
        CreateMap<CreateUserRequestDto, User>();
        CreateMap<UpdateUserInfoRequestDto, User>();
    }
}