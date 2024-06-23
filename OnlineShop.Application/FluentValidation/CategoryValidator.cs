using FluentValidation;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.FluentValidation;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId cannot be empty.");

        RuleFor(c => c.CategoryName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("CategoryName MaximumLength 100.");
    }
}
