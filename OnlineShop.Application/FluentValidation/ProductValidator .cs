using FluentValidation;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Maximum length of ProductName is 100");

        RuleFor(p => p.ProductDescription)
            .MaximumLength(500)
            .WithMessage("Maximum length of ProductDescription is 500");

        RuleFor(p => p.ProductPrice)
            .GreaterThan(0)
            .PrecisionScale(2, 14, false)
            .WithMessage("ProductPrice must have a maximum of 14 digits, including up to 2 decimal places");

        RuleFor(p => p.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId cannot be empty");
    }
}