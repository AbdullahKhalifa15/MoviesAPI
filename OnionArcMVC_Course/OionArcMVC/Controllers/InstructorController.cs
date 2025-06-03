using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositryLayer;

namespace OionArcMVC.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationContext _context;


        public InstructorController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> instructor = _context.Users.Where(s => s.InActive == true );
            return View(instructor);
        }
      
    }
}
