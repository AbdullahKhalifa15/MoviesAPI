using Hope.Web.Data;
using Hope.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hope.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this._context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Doctor = _context.Doctors.ToList().Take(4);
            ViewBag.Medicine = _context.Drugs.ToList().Take(2);
            ViewBag.Pharmacy = _context.Pharmacies.ToList().Take(3);
            ViewBag.Blog = _context.Awarenesses.ToList().Take(3);
            ViewBag.Charity = _context.Charities.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}