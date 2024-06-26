using FluentValidation;
using OnlineShop.Application.DTOs.UserDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.UserValidators;

public class CreateUserRequestDtoValidator : AbstractValidator<CreateUserRequestDto>
{
    public CreateUserRequestDtoValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(u => u.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Z]")
            .Matches("[a-z]")
            .Matches("[0-9]")
            .Matches("[^a-zA-Z0-9]");
    }
}
