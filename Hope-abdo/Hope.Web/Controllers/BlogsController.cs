using Hope.Web.Data;
using Hope.Web.Helper;
using Hope.Web.Model;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Hope.Web.Controllers
{
    
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context)
        {
            this._context = context;
        }
       
        public IActionResult Index()
        {
            var blogs = _context.Awarenesses.ToList();
            return View(blogs);
        }
        public IActionResult Details(int id)
        {
            var blog = _context.Awarenesses.Find(id);
            ViewBag.Blog = _context.Awarenesses.Where(s => s.Id != id).ToList();
            return View(blog);
        } 
      
        
    }
}
