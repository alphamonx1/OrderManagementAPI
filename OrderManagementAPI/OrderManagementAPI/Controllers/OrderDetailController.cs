using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Repositories;

namespace OrderManagementAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpPost("orders/{orderId}/orderdetails")]
        public async Task<IActionResult> CreateOrderDetail(int orderId, [FromBody] List<CreateOrderDetailRequest> request)
        {
            var result = await _orderDetailRepository.CreateOrderDetailAsync(orderId, request);
            return Ok(result);
        }

        [HttpGet("orders/{orderId}/orderdetails")]
        public async Task<IActionResult> GetOrderDetail(int orderId)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailAsync(orderId);
            return Ok(orderDetails);
        }

        [HttpDelete("orders/{orderId}/orderdetails/{orderDetailId}")]
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int orderDetailId)
        {
            var result = await _orderDetailRepository.DeleteOrderDetailFromOrderAsync(orderId, orderDetailId);
            return Ok(result);
        }
    }
}
