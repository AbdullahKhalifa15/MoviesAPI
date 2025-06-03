using Microsoft.AspNetCore.Mvc;

namespace Hope.Web.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
