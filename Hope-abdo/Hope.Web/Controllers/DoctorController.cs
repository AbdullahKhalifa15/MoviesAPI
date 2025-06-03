using CancerProject.Models;
using Hope.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
   
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Doctor> doctors=_context.Doctors.ToList();
            return View(doctors);
        }
    }
}
