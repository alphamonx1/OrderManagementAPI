using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Repositories;
using OrderManagementAPI.Application.UseCases.OrderUseCases.Repositories;
using OrderManagementAPI.Infrastructure.DatabaseContext;
using OrderManagementAPI.Infrastructure.UseCases.OrderDetailUseCases.Repositories;
using OrderManagementAPI.Infrastructure.UseCases.OrderUseCases.Repositories;

namespace OrderManagementAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderManagementDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository,OrderDetailRepository>();
            return services;
        }
    }
}
