using FluentValidation;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.FluentValidation;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.OrderId)
            .GreaterThan(0).WithMessage("Order ID must be greater than 0.");

        RuleFor(order => order.OrderDate)
            .NotEmpty().WithMessage("Order date is required.")
            .Must(BeAValidDate).WithMessage("Order date must be a valid date.");

        RuleFor(order => order.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(order => order.User)
            .NotNull().WithMessage("User is required.")
            .SetValidator(new UserValidator());
    }

    private bool BeAValidDate(DateTime date) => date <= DateTime.Now;
}
