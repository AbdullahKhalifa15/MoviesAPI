using CancerProject.Models;
using Hope.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
   
    public class PharmaciesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PharmaciesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Pharmacy> pharmacies = _context.Pharmacies;
            return View(pharmacies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            return View(pharmacy);
        }
        public IActionResult Pharmacymedicines()
        {

            return View();
        }

    }
}
