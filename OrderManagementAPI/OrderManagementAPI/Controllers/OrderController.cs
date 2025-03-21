using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs;
using OrderManagementAPI.Application.UseCases.OrderUseCases.Repositories;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderRepository orderRepository) : ControllerBase
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrderAsync();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = await _orderRepository.CreateNewOrderAsync(request);
            return CreatedAtAction(nameof(GetOrderById), new { status = result }, result);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] UpdateOrderRequest request)
        {
            var result = await _orderRepository.UpdateOrderAsync(orderId, request);
            return Ok(result);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var result = await _orderRepository.DeleteOrderAsync(orderId);
            return Ok(result);
        }
    }
}
