using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Shoes_project.Data;
using System.Linq;

namespace Shoes_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            
            var accessLevel = HttpContext.Session.GetInt32("AccessLevel");
            if (accessLevel == null)
            {
                return RedirectToAction("Login", "Account");
            }

            
            ViewBag.AccessLevel = accessLevel;

            DateTime today = DateTime.Now;

            var model = new HomeViewModel
            {
                EmployeeCount = _context.Employees.Count(),
                ProductCount = _context.Products.Count(),
                CustomerCount = _context.Customers.Count(),
                OrderCount = _context.Orders.Count(),
                DeliveryCount = _context.Deliveries.Count(),
                WarehouseCount = _context.Warehouses.Count(),
                PromotionCount = _context.Promotions.Count(),
                WeeklySales = _context.Orders
                  .Where(o => o.OrderDate >= today.AddDays(-7))
                  .Sum(o => (decimal?)o.TotalAmount) ?? 0,

                MonthlySales = _context.Orders
                  .Where(o => o.OrderDate.Month == today.Month &&
                   o.OrderDate.Year == today.Year)
                  .Sum(o => (decimal?)o.TotalAmount) ?? 0
            };

            return View(model);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Error()
        {
            return View();
        }
    }

    
    public class HomeViewModel
    {
        public int EmployeeCount { get; set; }
        public int ProductCount { get; set; }
        public int CustomerCount { get; set; }
        public int OrderCount { get; set; }
        public int DeliveryCount { get; set; }
        public int WarehouseCount { get; set; }
        public int PromotionCount { get; set; }
        public decimal WeeklySales { get; set; }
        public decimal MonthlySales { get; set; }

    }
}