using FluentValidation;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs;

namespace OrderManagementAPI.Application.UseCases.OrderUseCases.Validators
{
    public class CreateOrderDetailRequestValidator : AbstractValidator<CreateOrderDetailRequest>
    {
        public CreateOrderDetailRequestValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
