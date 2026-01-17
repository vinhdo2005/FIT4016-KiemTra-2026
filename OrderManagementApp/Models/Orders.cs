using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementApp.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("product_id")]
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        [Column("order_number")]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Column("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [EmailAddress]
        [Column("customer_email")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("delivery_date")]
        public DateTime? DeliveryDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public string Status => DeliveryDate.HasValue ? "Delivered" : "Pending";
    }
}