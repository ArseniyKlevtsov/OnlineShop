using FluentValidation;
using OnlineShop.Application.DTOs.UserDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.UserValidators;

public class UserLoginRequestDtoValidator : AbstractValidator<UserLoginRequestDto>
{
    public UserLoginRequestDtoValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(100);
    }
}
