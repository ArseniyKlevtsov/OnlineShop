using FluentValidation;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.OrederItemValidators;

public class CreateOrderItemRequestDtoValidator : AbstractValidator<CreateOrderItemRequestDto>
{
    public CreateOrderItemRequestDtoValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0)
            .WithMessage("Order ID must be a positive integer.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("Product ID must be a positive integer.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be a positive integer.");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0)
            .PrecisionScale(14, 2, true)
            .WithMessage("Unit price must be a positive decimal value with a maximum of 14 digits and 2 decimal places.");
    }
}