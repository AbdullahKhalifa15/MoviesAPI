
using DomainLayer;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OionArcMVC.ViewModel;
using RepositryLayer;
using RepositryLayer.Migrations;

namespace OionArcMVC.Controllers
{
    public class SessionController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SessionController(ApplicationContext context,UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult index(int id)
        {
            IEnumerable<Session> sessions = _context.Sessions.Include(c=>c.Course)
                .Where(s => s.CourseId == id).ToList();
            
            TempData["CourseId"] = id;             
            return View(sessions);
        }
        public IActionResult StartSession(int id)
        {
            var session = _context.Sessions.Find(id);
            return View(session);
        }
        // assignment 
        public async Task<IActionResult> Assignment(int id)
        {
            var assignments = await _context.Assignments.Include(sa=>sa.StudentAssignments).Where(s => s.SessionId == id).ToListAsync();
            if (assignments.Count()==0)
            {
                string text = "There is no assignment yet";
                return RedirectToAction("ErrorPage", "Admin", new { text });
            }
            var models = new List<AssginmentViewModel>();
            foreach (var assignment in assignments)
            {
                models.Add(new AssginmentViewModel()
                {
                     Id=assignment.Id,
                    DeadLine = assignment.DeadLine,
                    Question = assignment.Question,
                    Published = assignment.CreatedAt,
                    SessionId = assignment.SessionId
                });
            }

            var session = await _context.Sessions.FindAsync(id);
            ViewBag.SessionName = session.Description;
            return View(models);
        }
        public async Task<IActionResult> AssignmentSolution(int id)
        {
            var admin = await _signInManager.UserManager.GetUserAsync(User);
            TempData["AssignmentId"] = id;
            var assignmentsolution = await _context.StudentAssignments.FindAsync( admin.Id, id);
            if (assignmentsolution == null || assignmentsolution.Evaluation == null)
            {
                return View();
            }
            string text = "Your assignment has been evaluated";
            return RedirectToAction("ErrorPage", "Admin", new { text });
           
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AssignmentSolution(SolutionViewModel model)  
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                // find the row if it was found
                var studentassignment = await _context.StudentAssignments.FindAsync(user.Id,Convert.ToInt32(TempData["AssignmentId"]));
                if (studentassignment == null)
                {
                    await _context.StudentAssignments.AddAsync(new StudentAssignment
                    {
                        StudentId = user.Id,
                        AssignmentId = Convert.ToInt32(TempData["AssignmentId"]),
                        Solution = model.Solution
                    });
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Done");
                }
                else
                {
                    studentassignment.Solution = model.Solution;
                    _context.StudentAssignments.Update(studentassignment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Done");
                }

            }
            return View(model);
        }
        public IActionResult Done()
        {
            ViewBag.CourseId = TempData["CourseId"];
            return View();
        }
        // attendance of one student for all session that appears for user
        public async Task<IActionResult> Studentattend()
        {
            var admin = await _userManager.GetUserAsync(User);
            IEnumerable<Attendance> attendances = await _context.Attendances.Include(s=>s.ApplicationUser).Include(s=>s.session)
                .Where(s => s.StudentId.Equals(admin.Id)).ToListAsync();
            if (attendances.Count() == 0)
            {
                string text = "there is no attendance";
                return RedirectToAction("ErrorPage", "Admin", new {text});
            }
            List<StudentAttendViewModel> studentAttends = new List<StudentAttendViewModel>();
            foreach(var attendance in attendances)
            {
                studentAttends.Add(new StudentAttendViewModel
                {
                   NameOfSession=attendance.session.Description,
                   Date=attendance.CreatedAt,
                   IsAttendent=attendance.IsAttended
                });
            }
            return View(studentAttends);
        }

    }
}
