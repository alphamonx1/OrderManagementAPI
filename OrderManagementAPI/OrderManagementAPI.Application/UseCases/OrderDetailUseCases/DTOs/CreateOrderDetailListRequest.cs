namespace OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs
{
    public class CreateOrderDetailListRequest
    {
        public required List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }
}
