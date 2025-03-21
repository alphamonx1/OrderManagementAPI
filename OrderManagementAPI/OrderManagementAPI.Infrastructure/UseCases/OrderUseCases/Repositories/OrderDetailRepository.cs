using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Repositories;
using OrderManagementAPI.Domain.Entities;
using OrderManagementAPI.Infrastructure.DatabaseContext;

namespace OrderManagementAPI.Infrastructure.UseCases.OrderUseCases.Repositories
{
    public class OrderDetailRepository(OrderManagementDbContext context, IMapper mapper, ILogger<OrderDetailRepository> logger) : IOrderDetailRepository
    {
        private readonly OrderManagementDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger;

        public async Task<bool> CreateOrderDetailAsync(int OrderId, CreateOrderDetailListRequest request)
        {
            var result = false;
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == OrderId);
            if (order is not null)
            {
                var orderDetails = _mapper.Map<List<OrderDetails>>(request);
                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderId = OrderId;
                }
                await _context.OrderDetails.AddRangeAsync(orderDetails);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _logger.LogError("Order with ID {OrderId} not found", OrderId);
            }
            return result;
        }

        public async Task<bool> DeleteOrderDetailFromOrderAsync(int OrderId, int OrderDetailId)
        {
            var result = false;
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == OrderId);
            if (order is not null)
            {
                var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(x => x.OrderDetailId == OrderDetailId);
                if (orderDetail is not null)
                {
                    _context.OrderDetails.Remove(orderDetail);
                    result = await _context.SaveChangesAsync() > 0;
                }
                else
                {
                    _logger.LogError("Order detail with ID {OrderDetailId} not found", OrderDetailId);
                }
            }
            else
            {
                _logger.LogError("Order with ID {OrderId} not found", OrderId);
            }
            return result;
        }

        public async Task<List<GetOrderDetailResponse>> GetOrderDetailAsync(int OrderId)
        {
            var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == OrderId).ToListAsync();
            if (orderDetails.Count > 0)
            {
                return _mapper.Map<List<GetOrderDetailResponse>>(orderDetails);
            }
            else
            {
                _logger.LogError("No order details found for order with ID {OrderId}", OrderId);

                return [];
            }
        }
    }
}
