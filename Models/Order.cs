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
        public Product Product { get; set; }

        [Required]
        [Column("order_number")]
        public string OrderNumber { get; set; } // Format: ORD-YYYYMMDD-XXXX

        [Required]
        [MaxLength(100)] // Length 2-100 logic in Service
        [Column("customer_name")]
        public string CustomerName { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("customer_email")]
        public string CustomerEmail { get; set; } // Unique

        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("delivery_date")]
        public DateTime? DeliveryDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [cite_start]// Computed Status for display [cite: 39]
        [NotMapped]
        public string Status => DeliveryDate.HasValue ? "Delivered" : "Pending";
    }
}