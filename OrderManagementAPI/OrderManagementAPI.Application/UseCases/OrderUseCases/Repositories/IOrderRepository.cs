using OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs;

namespace OrderManagementAPI.Application.UseCases.OrderUseCases.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<GetOrderResponse>> GetAllOrderAsync();
        public Task<GetOrderResponse> GetOrderByIdAsync(int orderId);
        public Task<bool> CreateNewOrderAsync(CreateOrderRequest request);
        public Task<bool> UpdateOrderAsync(int orderId, UpdateOrderRequest request);

        public Task<bool> DeleteOrderAsync(int orderId);
    }
}
