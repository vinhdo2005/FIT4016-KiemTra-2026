using OrderManagementApp.Models;
using OrderManagementApp.Services;
using System;

namespace OrderManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            while (true)
            {
                Console.WriteLine("\n=== ORDER MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Create New Order");
                Console.WriteLine("2. View Orders List");
                Console.WriteLine("3. Update Order");
                Console.WriteLine("4. Delete Order");
                Console.WriteLine("5. Exit");
                Console.Write("Select option: ");
                
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Create UI
                        Order newOrder = new Order();
                        Console.WriteLine("\n--- Create Order ---");
                        Console.Write("Product ID: "); 
                        newOrder.ProductId = int.Parse(Console.ReadLine() ?? "0");
                        
                        Console.Write("Order Number (ORD-YYYYMMDD-XXXX): ");
                        newOrder.OrderNumber = Console.ReadLine();

                        Console.Write("Customer Name: ");
                        newOrder.CustomerName = Console.ReadLine();

                        Console.Write("Customer Email: ");
                        newOrder.CustomerEmail = Console.ReadLine();

                        Console.Write("Quantity: ");
                        int.TryParse(Console.ReadLine(), out int q);
                        newOrder.Quantity = q;

                        Console.Write("Order Date (yyyy-mm-dd): ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime oDate);
                        newOrder.OrderDate = oDate == DateTime.MinValue ? DateTime.Now : oDate;

                        service.CreateOrder(newOrder);
                        break;

                    case "2":
                        // Read UI
                        Console.Write("Enter page number: ");
                        int.TryParse(Console.ReadLine(), out int page);
                        page = page < 1 ? 1 : page;
                        
                        Console.Write("Search keyword (Enter to skip): ");
                        string keyword = Console.ReadLine();

                        service.GetAllOrders(page, keyword);
                        break;

                    case "3":
                        // Update UI
                        Console.Write("Enter Order ID to update: ");
                        int.TryParse(Console.ReadLine(), out int upId);
                        service.UpdateOrder(upId);
                        break;

                    case "4":
                        // Delete UI
                        Console.Write("Enter Order ID to delete: ");
                        int.TryParse(Console.ReadLine(), out int delId);
                        service.DeleteOrder(delId);
                        break;

                    case "5":
                        return;
                    
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}