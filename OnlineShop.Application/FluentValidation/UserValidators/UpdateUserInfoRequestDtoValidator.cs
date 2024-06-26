using FluentValidation;
using OnlineShop.Application.DTOs.UserDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.UserValidators;

public class UpdateUserInfoRequestDtoValidator : AbstractValidator<UpdateUserInfoRequestDto>
{
    public UpdateUserInfoRequestDtoValidator()
    {
        RuleFor(u => u.FirstName)
            .MaximumLength(50)
            .When(u => !string.IsNullOrEmpty(u.FirstName));

        RuleFor(u => u.LastName)
            .MaximumLength(50)
            .When(u => !string.IsNullOrEmpty(u.LastName));

        RuleFor(u => u.Email)
            .EmailAddress()
            .MaximumLength(100)
            .When(u => !string.IsNullOrEmpty(u.Email));
    }
}
