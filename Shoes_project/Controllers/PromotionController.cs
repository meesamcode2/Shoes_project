using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;

namespace Shoes_project.Controllers
{
    public class PromotionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromotionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var promotions = _context.Promotions.ToList();
            return View(promotions);
        }

        [HttpPost]
        public IActionResult Insert(Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                _context.Promotions.Add(promotion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", _context.Promotions.ToList());
        }

        [HttpPost]
        public IActionResult Update(Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                _context.Promotions.Update(promotion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", _context.Promotions.ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var promotion = _context.Promotions.Find(id);
            if (promotion != null)
            {
                _context.Promotions.Remove(promotion);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var promotions = _context.Promotions
                .Where(p => p.Title.Contains(search) || p.Description.Contains(search))
                .ToList();
            return View("Index", promotions);
        }
    }
}