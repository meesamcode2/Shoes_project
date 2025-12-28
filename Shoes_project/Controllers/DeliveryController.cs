using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;

namespace Shoes_project.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var deliveries = _context.Deliveries.Include(d => d.Order).ToList();
            ViewBag.Orders = _context.Orders.ToList();
            return View(deliveries);
        }

        [HttpPost]
        public IActionResult Insert(Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Deliveries.Add(delivery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Orders = _context.Orders.ToList();
            return View("Index", _context.Deliveries.Include(d => d.Order).ToList());
        }

        [HttpPost]
        public IActionResult Update(Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Deliveries.Update(delivery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Orders = _context.Orders.ToList();
            return View("Index", _context.Deliveries.Include(d => d.Order).ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delivery = _context.Deliveries.Find(id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var deliveries = _context.Deliveries
                .Include(d => d.Order)
                .Where(d => d.Courier.Contains(search) || d.DeliveryStatus.Contains(search))
                .ToList();

            ViewBag.Orders = _context.Orders.ToList();
            return View("Index", deliveries);
        }
    }
}