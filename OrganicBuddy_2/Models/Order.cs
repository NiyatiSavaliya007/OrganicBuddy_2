using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicBuddy_2.Models
{
    public class Order
    {
        public int Id { get; set; }

        // Assuming Product is another model representing products
        public List<OrderItem> Products { get; set; }
        [NotMapped]
        
        [EnumDataType(typeof(OrderStatus))]
        public string OrderStatus { get; set; } 
        // Assuming User is another model representing users
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
    public enum OrderStatus
    {
        NotProcessed,
        CashOnDelivery,
        Processing,
        Dispatched,
        Cancelled,
        Delivered
    }
}
