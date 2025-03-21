namespace OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs
{
    public class CreateOrderDetailListRequest
    {
        public List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }
}
