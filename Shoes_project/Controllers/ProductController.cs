using Microsoft.AspNetCore.Mvc;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;

namespace Shoes_project.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Always pass a non-null list to the view
            var products = _context.Products.ToList() ?? new List<Product>();
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Product product)
        {
            var existing = _context.Products.Find(id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.Name = product.Name;
                existing.Brand = product.Brand;
                existing.CategoryName = product.CategoryName;
                existing.Price = product.Price;
                existing.StockQuantity = product.StockQuantity;
                existing.SKU = product.SKU;
                existing.WarrantyMonths = product.WarrantyMonths;
                existing.Description = product.Description;
                existing.Supplier = product.Supplier;
                existing.ReleaseDate = product.ReleaseDate;

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products.Where(p =>
                    p.Name.Contains(search) ||
                    p.Brand.Contains(search) ||
                    p.CategoryName.Contains(search));
            }

            return View("Index", products.ToList() ?? new List<Product>());
        }
    }
}