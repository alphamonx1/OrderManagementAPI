using OrderManagementAPI.Domain.Enums;

namespace OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs
{
    public class CreateOrderRequest
    {
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
