using FluentValidation;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.FluentValidation;


public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("User ID cannot be empty.");

        RuleFor(u => u.UserName)
            .NotEmpty()
            .WithMessage("Username cannot be empty.")
            .MaximumLength(50)
            .WithMessage("Username cannot be longer than 50 characters.");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty.")
            .EmailAddress()
            .WithMessage("Invalid email address.");

        RuleFor(u => u.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty.")
            .MaximumLength(50)
            .WithMessage("First name cannot be longer than 50 characters.");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage("Last name cannot be empty.")
            .MaximumLength(50)
            .WithMessage("Last name cannot be longer than 50 characters.");

        RuleFor(u => u.PasswordHash)
            .NotEmpty()
            .WithMessage("Password hash cannot be empty.");

        RuleFor(u => u.SecurityStamp)
            .NotEmpty()
            .WithMessage("Security stamp cannot be empty.");

        RuleFor(u => u.EmailConfirmed)
            .NotNull()
            .WithMessage("Email confirmation status cannot be null.");

        RuleFor(u => u.PhoneNumberConfirmed)
            .NotNull()
            .WithMessage("Phone number confirmation status cannot be null.");

        RuleFor(u => u.AccessFailedCount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Access failed count cannot be negative.");
    }
}