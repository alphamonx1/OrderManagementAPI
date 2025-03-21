using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs;
using OrderManagementAPI.Application.UseCases.OrderUseCases.Repositories;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Infrastructure.DatabaseContext;

namespace OrderManagementAPI.Infrastructure.UseCases.OrderDetailUseCases.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(OrderManagementDbContext dbContext, IMapper mapper, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> CreateNewOrderAsync(CreateOrderRequest request)
        {
            var result = false;
            if (request != null)
            {
                var newOrder = _mapper.Map<Order>(request);
                await _dbContext.Orders.AddAsync(newOrder);
                result = await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                _logger.LogError("CreateOrderRequest is null");
            }
            return result;
        }

        public async Task<List<GetOrderResponse>> GetAllOrderAsync()
        {
            List<GetOrderResponse> orders = _mapper.Map<List<GetOrderResponse>>(await _dbContext.Orders.ToListAsync());
            if (orders.Count > 0)
            {
                return orders;
            }
            else
            {
                _logger.LogInformation("No orders found");
            }
            return [];
        }

        public async Task<GetOrderResponse> GetOrderByIdAsync(int orderId)
        {
            var order = _mapper.Map<GetOrderResponse>(await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId));
            if (order != null)
            {
                return order;
            }
            else
            {
                _logger.LogError("Order with ID {OrderId} not found", orderId);
            }
            return new GetOrderResponse();
        }

        public async Task<bool> UpdateOrderAsync(int orderId, UpdateOrderRequest request)
        {
            var result = false;
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (dbOrder != null)
            {
                dbOrder.CustomerName = request.CustomerName;
                dbOrder.TotalAmount = request.TotalAmount;
                dbOrder.Status = request.Status;
                dbOrder.UpdatedAt = request.UpdatedAt;
                _dbContext.Orders.Update(dbOrder);
                result = await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                _logger.LogError("Order with ID {orderId} not found", orderId);
            }
            return result;
        }

        public async Task<bool> UpdateOrderAsync(int orderId, CreateOrderRequest request)
        {
            var result = false;
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (dbOrder != null)
            {
                dbOrder.CustomerName = request.CustomerName;
                dbOrder.TotalAmount = request.TotalAmount;
                dbOrder.Status = request.Status;
                dbOrder.UpdatedAt = request.UpdatedAt;
                _dbContext.Orders.Update(dbOrder);
                result = await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                _logger.LogError("Order with ID {orderId} not found", orderId);
            }
            return result;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var result = false;
            var dbOrder = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (dbOrder != null)
            {
                _dbContext.Orders.Remove(dbOrder);
                result = await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                _logger.LogError("Order with ID {orderId} not found", orderId);
            }
            return result;
        }
    }
}
