using FluentValidation;
using OnlineShop.Application.DTOs.CategoryDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.CategoryValidators;

public class CategoryRequestDtoValidator : AbstractValidator<CategoryRequestDto>
{
    public CategoryRequestDtoValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("CategoryName MaximumLength 100.");
    }
}
