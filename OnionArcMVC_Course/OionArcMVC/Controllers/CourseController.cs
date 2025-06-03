using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositryLayer;
using ServiceLayer.CourseService;
using System;

namespace OionArcMVC.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
       
        private readonly ICourseService _context;
        public CourseController(ICourseService context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            IEnumerable<Course> courseList = _context.GetCourses();
            return View(courseList);  
        }

        // [HttpGet]
        [Authorize]
        public IActionResult Details(long id)
        {
            var details = _context.GetCourse(id);

            return View(details);
        }

    }
}
