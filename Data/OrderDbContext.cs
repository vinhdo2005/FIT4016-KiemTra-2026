using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;
using System;

namespace OrderManagementApp.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Cấu hình chuỗi kết nối (Cập nhật Server Name của bạn ở đây)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=OrderManagement;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            [cite_start]// --- 1. Constraints (Fluent API) [cite: 9] ---
            
            // Products: Name & SKU unique
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Sku).IsUnique();

            // Orders: OrderNumber & CustomerEmail unique
            modelBuilder.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(o => o.CustomerEmail).IsUnique();

            [cite_start]// --- 2. Data Seeding [cite: 10-12] ---
            
            // Seed 15 Products
            var products = new Product[15];
            for (int i = 1; i <= 15; i++)
            {
                products[i - 1] = new Product
                {
                    Id = i,
                    Name = $"IPhone 15 Pro Max Version {i}",
                    Sku = $"IPHONE-15-{i:000}",
                    Description = "High-end smartphone",
                    Price = 1000 + (i * 10),
                    StockQuantity = 50 + i,
                    Category = "Electronics",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            modelBuilder.Entity<Product>().HasData(products);

            // Seed 30 Orders
            var orders = new Order[30];
            var baseDate = DateTime.Now.AddDays(-20);
            for (int i = 1; i <= 30; i++)
            {
                orders[i - 1] = new Order
                {
                    Id = i,
                    ProductId = (i % 15) + 1, // Link to existing products
                    OrderNumber = $"ORD-{baseDate:yyyyMMdd}-{i:0000}",
                    CustomerName = $"User Test {i}",
                    CustomerEmail = $"user{i}@test.com",
                    Quantity = 1,
                    OrderDate = baseDate,
                    // Half delivered, half pending
                    DeliveryDate = i % 2 == 0 ? baseDate.AddDays(3) : (DateTime?)null,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            modelBuilder.Entity<Order>().HasData(orders);
        }
    }
}