using Microsoft.AspNetCore.Mvc;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shoes_project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Always pass a non-null list
            var customers = _context.Customers.ToList() ?? new List<Customer>();
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Customer customer)
        {
            var existing = _context.Customers.Find(id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.FullName = customer.FullName;
                existing.Email = customer.Email;
                existing.PhoneNumber = customer.PhoneNumber;
                existing.Address = customer.Address;
                existing.City = customer.City;
                existing.PostalCode = customer.PostalCode;
                existing.Country = customer.Country;
                existing.MembershipStatus = customer.MembershipStatus;
                existing.TotalSpend = customer.TotalSpend;
                existing.JoinDate = customer.JoinDate;

                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                customers = customers.Where(c =>
                    c.FullName.Contains(search) || c.Email.Contains(search));
            }

            return View("Index", customers.ToList() ?? new List<Customer>());
        }
    }
}