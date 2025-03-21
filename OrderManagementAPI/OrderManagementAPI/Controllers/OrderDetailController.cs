using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.DTOs;
using OrderManagementAPI.Application.UseCases.OrderDetailUseCases.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    [Route("api/orders/{orderId}/orderdetails")]
    public class OrderDetailController(IOrderDetailRepository orderDetailRepository) : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository = orderDetailRepository;

        /// <summary>
        /// Create multiple order detail lines for a specific order
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        /// <param name="request">List of order detail lines to be created</param>
        /// <returns>The created order detail items</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create order details",
            Description = "Create one or more order detail line items for a specific order"
        )]
        [SwaggerResponse(200, "Order details created successfully", typeof(IEnumerable<GetOrderDetailResponse>))]
        [SwaggerResponse(400, "Invalid input")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> CreateOrderDetail(
            [SwaggerParameter(Description = "The ID of the order")] int orderId,
            [FromBody, SwaggerParameter(Description = "List of order detail items to create")]
            CreateOrderDetailListRequest request)
        {
            var result = await _orderDetailRepository.CreateOrderDetailAsync(orderId, request);
            return Ok(result);
        }

        /// <summary>
        /// Get all order detail lines for a specific order
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        /// <returns>List of order detail lines</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get order details by order ID",
            Description = "Retrieve all order detail lines belonging to a specific order"
        )]
        [SwaggerResponse(200, "Order details retrieved successfully", typeof(List<GetOrderDetailResponse>))]
        [SwaggerResponse(404, "Order not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetOrderDetail(
            [SwaggerParameter(Description = "The ID of the order")] int orderId)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailAsync(orderId);
            return Ok(orderDetails);
        }

        /// <summary>
        /// Delete a specific order detail from an order
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        /// <param name="orderDetailId">The ID of the order detail to delete</param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("{orderDetailId}")]
        [SwaggerOperation(
            Summary = "Delete an order detail line",
            Description = "Deletes a specific order detail item from a given order"
        )]
        [SwaggerResponse(200, "Order detail deleted successfully")]
        [SwaggerResponse(404, "Order or detail not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> DeleteOrderDetail(
            [SwaggerParameter(Description = "The ID of the order")] int orderId,
            [SwaggerParameter(Description = "The ID of the order detail to delete")] int orderDetailId)
        {
            var result = await _orderDetailRepository.DeleteOrderDetailFromOrderAsync(orderId, orderDetailId);
            return Ok(result);
        }
    }
}
