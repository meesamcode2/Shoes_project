using Microsoft.AspNetCore.Mvc;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shoes_project.Controllers
{
    public class MembershipLevelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipLevelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var levels = _context.MembershipLevels.ToList() ?? new List<MembershipLevel>();
            return View(levels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(MembershipLevel level)
        {
            if (ModelState.IsValid)
            {
                _context.MembershipLevels.Add(level);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, MembershipLevel level)
        {
            var existing = _context.MembershipLevels.Find(id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.Name = level.Name;
                existing.DiscountPercentage = level.DiscountPercentage;
                existing.MinimumSpend = level.MinimumSpend;
                existing.Benefits = level.Benefits;

                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var level = _context.MembershipLevels.Find(id);
            if (level != null)
            {
                _context.MembershipLevels.Remove(level);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var levels = _context.MembershipLevels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                levels = levels.Where(l => l.Name.Contains(search));
            }

            return View("Index", levels.ToList());
        }
    }
}