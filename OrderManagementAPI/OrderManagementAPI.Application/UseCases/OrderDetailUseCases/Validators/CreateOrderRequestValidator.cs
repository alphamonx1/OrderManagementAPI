using FluentValidation;
using OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs;

namespace OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.TotalAmount).GreaterThan(0);
        }
    }
}
