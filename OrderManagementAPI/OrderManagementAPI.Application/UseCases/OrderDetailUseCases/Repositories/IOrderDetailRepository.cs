using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs;

namespace OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<bool> CreateOrderDetailAsync(int OrderId, List<CreateOrderDetailRequest> request);
        Task<List<GetOrderDetailResponse>> GetOrderDetailAsync(int OrderId);
        Task<bool> DeleteOrderDetailFromOrderAsync(int OrderId, int OrderDetailId);
    }
}
