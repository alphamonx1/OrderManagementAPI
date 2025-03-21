namespace OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs
{
    public class GetOrderDetailResponse
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
