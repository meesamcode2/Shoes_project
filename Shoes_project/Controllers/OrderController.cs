using Microsoft.AspNetCore.Mvc;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;

namespace Shoes_project.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        // POST: Order/Insert
        [HttpPost]
        public IActionResult Insert(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Order/Update
        [HttpPost]
        public IActionResult Update(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Order/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Order/Search
        [HttpPost]
        public IActionResult Search(string search)
        {
            var orders = _context.Orders
                .Where(o => o.CustomerName.Contains(search) || o.CustomerEmail.Contains(search))
                .ToList();
            return View("Index", orders);
        }
    }
}