using Hope.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
    public class CharityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharityController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index(int id)
        {
            var charity = _context.Charities.Find(id);
            ViewBag.Charity = _context.Charities.Where(s => s.Id != id).ToList();
            return View(charity);
        }
    }
}
