using OrderManagementAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
