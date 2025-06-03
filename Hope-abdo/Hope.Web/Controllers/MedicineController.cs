using CancerProject.Models;
using Hope.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
    //[Authorize]
    public class MedicineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public MedicineController(ApplicationDbContext context, SignInManager<ApplicationUser> signIn)
        {
            _context = context;
            _signInManager = signIn;

        }
        public IActionResult Index()
        {
            var medicines = _context.Drugs.ToList();
            return View(medicines);
        }
        public IActionResult Details(string data)
        {
            var medicines = _context.Drugs.Where(m => m.TypeOfCancer.Equals(data)).ToList();

            return View(medicines);
        }
    }
}
