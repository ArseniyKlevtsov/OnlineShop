using FluentValidation;
using OnlineShop.Application.DTOs.ProductDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.ProductValidators;

public class ProductRequestDtoValidator : AbstractValidator<ProductRequestDto>
{
    public ProductRequestDtoValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Product name is required and must not exceed 100 characters.");

        RuleFor(p => p.ProductDescription)
            .MaximumLength(500)
            .WithMessage("Product description must not exceed 500 characters.");

        RuleFor(p => p.ProductPrice)
            .GreaterThan(0)
            .PrecisionScale(14, 2, true)
            .WithMessage("Product price must be a positive decimal value with a maximum of 14 digits and 2 decimal places.");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0)
            .WithMessage("Category ID must be a positive integer.");
    }
}
