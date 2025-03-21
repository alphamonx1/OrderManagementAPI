using FluentValidation;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs;
using OrderManagementAPI.Application.UseCases.OrderUseCases.Validators;

public class CreateOrderDetailListRequestValidator : AbstractValidator<CreateOrderDetailListRequest>
{
    public CreateOrderDetailListRequestValidator()
    {
        RuleFor(x => x.OrderDetails).NotEmpty();

        RuleForEach(x => x.OrderDetails).SetValidator(new CreateOrderDetailRequestValidator());
    }
}