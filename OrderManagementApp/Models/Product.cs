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
        [StringLength(255)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column("sku")]
        public string Sku { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Required]
        [StringLength(100)]
        [Column("category")]
        public string Category { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}