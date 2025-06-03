using CancerProject.Models;
using Hope.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
   
    public class HospitalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HospitalsController(ApplicationDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
           var hospitals = _context.Hospitals.ToList();
            return View(hospitals);
        }
    }
}
