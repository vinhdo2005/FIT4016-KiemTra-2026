using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;
using System;

namespace OrderManagementApp.Data
{
    public class OrderDbContext : DbContext
    {
        // Constructor mặc định rất quan trọng để tránh lỗi "No DbContext was found"
        public OrderDbContext() { }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thay "Server=." bằng tên SQL Server của bạn nếu dùng bản Express: "Server=.\\SQLEXPRESS"
                optionsBuilder.UseSqlServer("Server=.;Database=OrderManagement;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Constraints (Fluent API)
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Sku).IsUnique();

            modelBuilder.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(o => o.CustomerEmail).IsUnique();

            // 2. Data Seeding
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
                    ProductId = (i % 15) + 1,
                    OrderNumber = $"ORD-{baseDate:yyyyMMdd}-{i:0000}",
                    CustomerName = $"User Test {i}",
                    CustomerEmail = $"user{i}@test.com",
                    Quantity = 1,
                    OrderDate = baseDate,
                    DeliveryDate = i % 2 == 0 ? baseDate.AddDays(3) : (DateTime?)null,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            modelBuilder.Entity<Order>().HasData(orders);
        }
    }
}
