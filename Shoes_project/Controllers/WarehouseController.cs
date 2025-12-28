using Microsoft.AspNetCore.Mvc;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shoes_project.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var warehouses = _context.Warehouses.ToList() ?? new List<Warehouse>();
            return View(warehouses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Warehouses.Add(warehouse);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Warehouse warehouse)
        {
            var existing = _context.Warehouses.Find(id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.Name = warehouse.Name;
                existing.Location = warehouse.Location;
                existing.City = warehouse.City;
                existing.Country = warehouse.Country;
                existing.Capacity = warehouse.Capacity;
                existing.ManagerName = warehouse.ManagerName;
                existing.ContactNumber = warehouse.ContactNumber;

                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var warehouses = _context.Warehouses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                warehouses = warehouses.Where(w =>
                    w.Name.Contains(search) ||
                    w.City.Contains(search));
            }

            return View("Index", warehouses.ToList());
        }
    }
}