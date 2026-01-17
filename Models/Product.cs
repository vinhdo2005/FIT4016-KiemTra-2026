using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementApp.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } // Unique configured in Fluent API

        [Required]
        [Column("sku")]
        public string Sku { get; set; } // Unique configured in Fluent API

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Required]
        [Column("category")]
        public string Category { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public ICollection<Order> Orders { get; set; }
    }
}