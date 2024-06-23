using FluentValidation;
using OnlineShop.Application.DTOs.Category.Requests;

namespace OnlineShop.Application.FluentValidation;

public class CategoryValidator : AbstractValidator<CategoryCreateRequestDto>
{
    public CategoryValidator()
    {
        RuleFor(c => c.CategoryName)
            .NotEmpty()
            .MaximumLength(100);
    }
}
