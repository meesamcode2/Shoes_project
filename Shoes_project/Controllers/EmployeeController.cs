using Microsoft.AspNetCore.Mvc;
//using Shoes.Data;
using Shoes_project.Data;
using Shoes_project.Models;

namespace Shoes.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Employee employee)
        {
            var cat = _context.Employees.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                cat.Name = employee.Name;
                cat.Title = employee.Title;
                cat.ContactNumber = employee.ContactNumber;
                cat.Email = employee.Email;
                cat.Department = employee.Department;
                cat.Salary = employee.Salary;
                cat.HireDate = employee.HireDate;
                cat.Address = employee.Address;
                cat.City = employee.City;
                cat.EmergencyContact = employee.EmergencyContact;

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var cat = _context.Employees.Find(id);
            if (cat != null)
            {
                _context.Employees.Remove(cat);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string search)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                employees = employees.Where(e => e.Name.Contains(search));
            }

            return View("Index", employees.ToList());
        }
    }
}