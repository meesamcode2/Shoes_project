using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoes_project.Data;
using Shoes_project.Models;
using System.Linq;

namespace Shoes_project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                // Save user info in session
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetInt32("AccessLevel", user.AccessLevel);
                HttpContext.Session.SetString("Username", user.Username);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        // GET: /Account/Signup
        public IActionResult Signup()
        {
            return View();
        }

        // POST: /Account/Signup
        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ViewBag.Error = "Email already registered";
                    return View();
                }

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        // POST: /Account/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}