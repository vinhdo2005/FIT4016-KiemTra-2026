using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Data;
using OrderManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace OrderManagementApp.Services
{
    public class OrderService
    {
        private readonly OrderDbContext _context;

        public OrderService()
        {
            _context = new OrderDbContext();
        }

        // --- VALIDATION HELPER ---
        [cite_start]// Validate dữ liệu đầu vào theo yêu cầu [cite: 17-24]
        private void ValidateOrder(Order order, bool isUpdate)
        {
            // 1. Order Number: Format ORD-YYYYMMDD-XXXX
            string pattern = @"^ORD-\d{8}-\d{4}$";
            if (!Regex.IsMatch(order.OrderNumber, pattern))
                throw new Exception("Validation Error: Order Number must match format 'ORD-YYYYMMDD-XXXX'.");

            // 2. Customer Name: 2-100 chars
            if (string.IsNullOrWhiteSpace(order.CustomerName) || order.CustomerName.Length < 2 || order.CustomerName.Length > 100)
                throw new Exception("Validation Error: Customer Name must be between 2 and 100 characters.");

            // 3. Email: Valid format
            if (!new EmailAddressAttribute().IsValid(order.CustomerEmail))
                throw new Exception("Validation Error: Invalid email format.");

            // 4. Product Check & Stock Logic
            var product = _context.Products.Find(order.ProductId);
            if (product == null) 
                throw new Exception("Validation Error: Product not found.");

            if (order.Quantity <= 0)
                throw new Exception("Validation Error: Quantity must be greater than 0.");

            // Nếu update và thay đổi số lượng, logic kiểm tra tồn kho phức tạp hơn, 
            // nhưng ở đây ta làm đơn giản theo yêu cầu đề bài: Quantity <= StockQuantity
            if (order.Quantity > product.StockQuantity)
                throw new Exception($"Validation Error: Quantity ({order.Quantity}) exceeds stock ({product.StockQuantity}).");

            // 5. Date Logic
            if (order.OrderDate.Date > DateTime.Now.Date)
                throw new Exception("Validation Error: Order Date cannot be in the future.");

            if (order.DeliveryDate.HasValue && order.DeliveryDate.Value < order.OrderDate)
                throw new Exception("Validation Error: Delivery Date must be >= Order Date.");

            // 6. Unique Constraints Check
            // Check Duplicate Email (excluding current order if update)
            var emailExists = _context.Orders.Any(o => o.CustomerEmail == order.CustomerEmail && o.Id != order.Id);
            if (emailExists)
                throw new Exception("Validation Error: Customer Email already exists.");

            // Check Duplicate OrderNumber (only for Create)
            if (!isUpdate)
            {
                if (_context.Orders.Any(o => o.OrderNumber == order.OrderNumber))
                    throw new Exception("Validation Error: Order Number already exists.");
            }
        }

        [cite_start]// --- CREATE [cite: 14] ---
        public void CreateOrder(Order order)
        {
            try
            {
                ValidateOrder(order, isUpdate: false);
                _context.Orders.Add(order);
                _context.SaveChanges();
                Console.WriteLine("Success: Order created successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        [cite_start]// --- READ (Pagination & Search) [cite: 26] ---
        public void GetAllOrders(int pageNumber, string keyword = "")
        {
            int pageSize = 10; // [cite: 31]
            var query = _context.Orders.Include(o => o.Product).AsQueryable();

            [cite_start]// Search [cite: 40]
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(o => o.OrderNumber.ToLower().Contains(keyword) || 
                                         o.CustomerName.ToLower().Contains(keyword));
            }

            int totalRecords = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var orders = query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();

            // Display Table
            Console.Clear();
            Console.WriteLine($"--- ORDER LIST (Page {pageNumber}/{totalPages} | Total: {totalRecords}) ---");
            Console.WriteLine(new string('-', 115));
            Console.WriteLine($"| {"Order Number",-20} | {"Customer",-15} | {"Email",-20} | {"Product",-15} | {"Qty",-5} | {"Date",-10} | {"Status",-10} |");
            Console.WriteLine(new string('-', 115));

            foreach (var item in orders)
            {
                Console.WriteLine($"| {item.OrderNumber,-20} | {item.CustomerName,-15} | {item.CustomerEmail,-20} | {item.Product.Name.Substring(0, Math.Min(15, item.Product.Name.Length)),-15} | {item.Quantity,-5} | {item.OrderDate:dd/MM/yyyy} | {item.Status,-10} |");
            }
            Console.WriteLine(new string('-', 115));
        }

        [cite_start]// --- UPDATE [cite: 42] ---
        public void UpdateOrder(int orderId)
        {
            var order = _context.Orders.Include(o => o.Product).FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                Console.WriteLine("Error: Order not found.");
                return;
            }

            Console.WriteLine($"Updating Order: {order.OrderNumber}");
            
            [cite_start]// Chỉ cập nhật các trường được phép [cite: 47-48]
            Console.Write($"Enter new Customer Name ({order.CustomerName}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) order.CustomerName = name;

            Console.Write($"Enter new Email ({order.CustomerEmail}): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) order.CustomerEmail = email;

            Console.Write($"Enter new Quantity ({order.Quantity}): ");
            string qtyStr = Console.ReadLine();
            if (int.TryParse(qtyStr, out int qty)) order.Quantity = qty;

            Console.Write("Enter Delivery Date (yyyy-mm-dd) or Enter to skip: ");
            string dateStr = Console.ReadLine();
            if (DateTime.TryParse(dateStr, out DateTime dDate)) order.DeliveryDate = dDate;

            order.UpdatedAt = DateTime.Now;

            try
            {
                ValidateOrder(order, isUpdate: true);
                _context.SaveChanges();
                Console.WriteLine("Success: Order updated successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message); // [cite: 50]
                Console.ResetColor();
                // Reload entity from DB to discard invalid changes in context if needed
                _context.Entry(order).Reload();
            }
        }

        [cite_start]// --- DELETE [cite: 52] ---
        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null)
            {
                Console.WriteLine("Error: Order not found.");
                return;
            }

            [cite_start]// Confirm Dialog [cite: 57]
            Console.Write($"Are you sure you want to delete order {order.OrderNumber}? (y/n): ");
            var confirm = Console.ReadLine();

            if (confirm?.ToLower() == "y")
            {
                try
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                    Console.WriteLine("Success: Order deleted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting order: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }
    }
}