using OrderManagementAPI.Domain.Enums;

namespace OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs
{
    public class GetOrderResponse
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
