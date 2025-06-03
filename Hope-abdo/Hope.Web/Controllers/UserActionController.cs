using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
    public class UserActionController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult Liked()
        {
            return View();
        }
        public IActionResult SavedArtical()
        {
            return View();
        }


    }
}
