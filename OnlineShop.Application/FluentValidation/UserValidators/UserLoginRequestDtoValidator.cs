using FluentValidation;
using OnlineShop.Application.DTOs.UserDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.UserValidators;

public class UserLoginRequestDtoValidator : AbstractValidator<UserLoginRequestDro>
{
    public UserLoginRequestDtoValidator()
    {
        RuleFor(u => u.Login)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(u => u.Passwrod)
            .NotEmpty()
            .MaximumLength(100);
    }
}
