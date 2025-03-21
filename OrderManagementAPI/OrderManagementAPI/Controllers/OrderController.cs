using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.UseCases.OrderUseCases.DTOs;
using OrderManagementAPI.Application.UseCases.OrderUseCases.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderRepository orderRepository) : ControllerBase
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>List of all orders</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all orders",
            Description = "Retrieves all available orders from the system"
        )]
        [SwaggerResponse(200, "Orders loaded successfully", typeof(IEnumerable<GetOrderResponse>))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrderAsync();
            return Ok(orders);
        }

        /// <summary>
        /// Get an order by its ID
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        /// <returns>The order data</returns>
        [HttpGet("{orderId}")]
        [SwaggerOperation(
            Summary = "Get order by ID",
            Description = "Retrieves a specific order based on the provided order ID"
        )]
        [SwaggerResponse(200, "Order found", typeof(GetOrderResponse))]
        [SwaggerResponse(404, "Order not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetOrderById(
            [SwaggerParameter(Description = "Unique ID of the order")] int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="request">Order creation data</param>
        /// <returns>The created order</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new order",
            Description = "Creates a new order in the system using the provided data"
        )]
        [SwaggerResponse(201, "Order created", typeof(GetOrderResponse))]
        [SwaggerResponse(400, "Invalid input")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> CreateOrder(
            [FromBody, SwaggerParameter(Description = "Order data to be created")] CreateOrderRequest request)
        {
            var result = await _orderRepository.CreateNewOrderAsync(request);
            return CreatedAtAction(nameof(CreateOrder), new { status = result }, result);
        }

        /// <summary>
        /// Update an existing order
        /// </summary>
        /// <param name="orderId">ID of the order to update</param>
        /// <param name="request">Updated order data</param>
        /// <returns>The updated order</returns>
        [HttpPut("{orderId}")]
        [SwaggerOperation(
            Summary = "Update an order",
            Description = "Updates an existing order by ID using the provided data"
        )]
        [SwaggerResponse(200, "Order updated", typeof(GetOrderResponse))]
        [SwaggerResponse(400, "Invalid input")]
        [SwaggerResponse(404, "Order not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> UpdateOrder(
            [SwaggerParameter(Description = "ID of the order to update")] int orderId,
            [FromBody, SwaggerParameter(Description = "Updated order data")] UpdateOrderRequest request)
        {
            var result = await _orderRepository.UpdateOrderAsync(orderId, request);
            return Ok(result);
        }

        /// <summary>
        /// Delete an order
        /// </summary>
        /// <param name="orderId">ID of the order to delete</param>
        /// <returns>Confirmation of deletion</returns>
        [HttpDelete("{orderId}")]
        [SwaggerOperation(
            Summary = "Delete an order",
            Description = "Deletes an order from the system using its ID"
        )]
        [SwaggerResponse(200, "Order deleted")]
        [SwaggerResponse(404, "Order not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> DeleteOrder(
            [SwaggerParameter(Description = "ID of the order to delete")] int orderId)
        {
            var result = await _orderRepository.DeleteOrderAsync(orderId);
            return Ok(result);
        }
    }
}
