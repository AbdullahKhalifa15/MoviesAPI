using CancerProject.Models;
using DomainLayer.Models;
using Hope.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
    [Authorize]
    public class DashBoardController : Controller

    {

        private readonly ApplicationDbContext _context;
        public DashBoardController(ApplicationDbContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Doctor  = _context.Doctors.Count();
            ViewBag.Hospital=_context.Hospitals.Count();
            ViewBag.Drug=_context.Drugs.Count();
            ViewBag.Pharmacy = _context.Pharmacies.Count();
            ViewBag.Blog = _context.Awarenesses.Count();
            ViewBag.Charities = _context.Charities.Count();
            return View();
        }
        public IActionResult Doctor()
        {
            IEnumerable<Doctor> doctor=_context.Doctors;
            return View(doctor);
        }
        public IActionResult Medicine()
        {
            IEnumerable<Drugs> drugs = _context.Drugs;
            return View(drugs);
        }
        public IActionResult Hospital()
        {
            IEnumerable<Hospital> hospitals = _context.Hospitals;
            return View(hospitals);
        }
        public IActionResult Pharmacy()
        {
            IEnumerable<Pharmacy> pharmacies = _context.Pharmacies;
            return View(pharmacies);
        }
        public IActionResult Blog()
        {
            IEnumerable<Awareness> awarenesses = _context.Awarenesses;
            return View(awarenesses);

        }
        public IActionResult Charity()
        {
            IEnumerable<Charities> charities = _context.Charities;
            return View(charities);

        }
    }
}
