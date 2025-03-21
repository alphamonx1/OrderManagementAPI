namespace OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs
{
    public class CreateOrderDetailRequest
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
