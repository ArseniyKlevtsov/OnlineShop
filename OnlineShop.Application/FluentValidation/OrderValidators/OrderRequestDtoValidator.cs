using FluentValidation;
using OnlineShop.Application.DTOs.OrderDTOs.Requests;

namespace OnlineShop.Application.FluentValidation.OrderValidators;

public class OrderRequestDtoValidator : AbstractValidator<OrderRequestDto>
{
    public OrderRequestDtoValidator()
    {
        RuleFor(x => x.OrderDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Order date must be a valid date and not in the future.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .MaximumLength(70)
            .WithMessage("User ID must be provided and cannot exceed 70 characters.");

        RuleFor(x => x.OrderItems)
            .NotEmpty()
            .WithMessage("At least one order item must be provided.")
            .Must(items => items.All(item => item.Quantity > 0 && item.ProductId > 0))
            .WithMessage("Each order item must have a valid quantity and product ID.");
    }
}