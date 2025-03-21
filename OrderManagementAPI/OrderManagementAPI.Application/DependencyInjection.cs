using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Validators;
using OrderManagementAPI.Application.UseCases.OrderUseCases.Validators;

namespace OrderManagementAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateOrderDetailRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateOrderDetailListRequestValidator>();
            services.AddFluentValidationAutoValidation();
            return services;
        }   
    }
}
