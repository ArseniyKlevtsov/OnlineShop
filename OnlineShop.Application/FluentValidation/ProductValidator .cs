using FluentValidation;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(p => p.ProductDescription)
            .MaximumLength(500);

        RuleFor(p => p.ProductPrice)
            .GreaterThan(0)
            .PrecisionScale(2, 14, false);

        RuleFor(p => p.CategoryId)
            .NotEmpty();
    }
}