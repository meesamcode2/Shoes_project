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

        // Dashboard
        public IActionResult Index()
        {
            // Redirect to login if not logged in
            var accessLevel = HttpContext.Session.GetInt32("AccessLevel");
            if (accessLevel == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Pass access level to view
            ViewBag.AccessLevel = accessLevel;

            var model = new HomeViewModel
            {
                EmployeeCount = _context.Employees.Count(),
                ProductCount = _context.Products.Count(),
                CustomerCount = _context.Customers.Count(),
                OrderCount = _context.Orders.Count(),
                DeliveryCount = _context.Deliveries.Count(),
                WarehouseCount = _context.Warehouses.Count(),
                PromotionCount = _context.Promotions.Count()
            };

            return View(model);
        }

        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Optional: Error page
        public IActionResult Error()
        {
            return View();
        }
    }

    // Dashboard view model
    public class HomeViewModel
    {
        public int EmployeeCount { get; set; }
        public int ProductCount { get; set; }
        public int CustomerCount { get; set; }
        public int OrderCount { get; set; }
        public int DeliveryCount { get; set; }
        public int WarehouseCount { get; set; }
        public int PromotionCount { get; set; }
    }
}