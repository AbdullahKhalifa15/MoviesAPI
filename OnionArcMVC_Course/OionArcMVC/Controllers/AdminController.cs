using DomainLayer;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OionArcMVC.Models;
using OionArcMVC.ViewModel;
using RepositryLayer;
using ServiceLayer.AttendenceService;
using ServiceLayer.CourseService;

namespace OionArcMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAttendenceService _attendenceService;

        public AdminController(ApplicationContext context , SignInManager<ApplicationUser> signInManager, IAttendenceService attendenceService)
        {
            _context = context;
            _signInManager = signInManager;
            _attendenceService = attendenceService;
        }
        public IActionResult Index()
        {

            IEnumerable<Course> courseList = _context.Courses;
            return View(courseList);
        }
        public IActionResult Add()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Course course)
        {
            var admin = _signInManager.UserManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                course.CreatedBy = admin;
                _context.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course item)
        {
            if (ModelState.IsValid)
            {
               
                _context.Courses.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View(item);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Course course)
        {

            if (course == null)
            {
                // Item not found
                return NotFound();
            }
            // Remove the item from the database
            var student = _context.Users.Where(s => s.CourseId == course.Id).ToList();
            var session = _context.Sessions.Where(s => s.CourseId == course.Id).ToList();
            foreach( var item in student)
            {
                item.CourseId = null;
                _context.Remove(item);
                _context.SaveChanges();
            }
            foreach (var item in session)
            {
                item.CourseId = null;
                _context.Remove(item);
                _context.SaveChanges();
            }
            _context.Remove(course);
            _context.SaveChanges();

            // Redirect to the index page or another appropriate page
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> StudentList()
        {

            var users = await _context.Users.Include(a => a.Course).Where(s=> s.CourseId!=null)
                .ToListAsync();

            return View(users);
            
        }
     
        // session part
        public IActionResult CourseList()
        {
            IEnumerable<Course> courses = _context.Courses;
            return View(courses);
        }
        public IActionResult SessionList(int id)
        {
            if (id != 0)
            {
                IEnumerable<Session> sessions = _context.Sessions.Include(s => s.Course).Where(s => s.CourseId == id);
                ViewBag.coursename = sessions.Select(s => s.Course.Title).FirstOrDefault();
                TempData["CourseId"] = id;
                return View(sessions);
            }
          return RedirectToAction("ErrorPage", "Admin");

        }
        public IActionResult AddSession()
        {
            CreateSelectList(null);
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddSession(SessionViewModel model)
        {
            var admin = await _signInManager.UserManager.GetUserAsync(User);
            var session = new Session
            {
                Description = model.Description,
                Date = model.Date,
                Material = model.Material,
                CourseId = model.CourseId,
                 CreatedBy=admin.Id
            };
          await _context.Sessions.AddAsync(session);
          await _context.SaveChangesAsync();
            //get this session for get its id
            var session1 = await _context.Sessions.Where(s => s.Description == model.Description).FirstOrDefaultAsync();
            var student = await _context.Users.Where(s => s.CourseId ==model.CourseId).ToListAsync();
            foreach(var std in student)
            {
                 _attendenceService.InsertAttendence(new Attendance
                {
                    StudentId = std.Id,
                    SessionId=session1.Id,
                     CreatedBy = admin.Id
                 });
                _attendenceService.SaveChanges();
            }
            return RedirectToAction("CourseList");
        }
        public IActionResult Editsession(int id)
        {
            var sessions = _context.Sessions.Find(id);
 
            CreateSelectList(sessions.CourseId);
            return View(sessions);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Editsession(Session session)
        {
            var admin = _signInManager.UserManager.GetUserId(User);
            session.CreatedBy = admin;
            _context.Sessions.Update(session);
            _context.SaveChanges();
            return RedirectToAction("CourseList");
        }
     
        public IActionResult Deletesession(int id)
        {
            var session = _context.Sessions.Find(id);
            _context.Sessions.Remove(session);
            _context.SaveChanges();
            return RedirectToAction("CourseList");
        }
        // attendence part --not work
        public IActionResult Attendance(int id)
        {
            var session = _context.Sessions.Find(id);
            var course = _context.Courses.Find(session.CourseId);
            var student = _context.Users.Where(s => s.CourseId == course.Id).ToList();
            var attendances = new List<AttendanceViewModel>();
           foreach(var std in student)
           {
                var attendace =new AttendanceViewModel()
                {
                    StudentId=std.Id,
                    FirstName = std.FirstName,
                    LastName = std.LastName,
                    Email = std.Email,
                    SessionId=id,
                    CreatedAt=DateTime.Now
                    
                };
                attendances.Add(attendace);
           }
            ViewBag.SessionName = session.Description;
            return View(attendances);
        }
       // not work
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Attendance(List<AttendanceViewModel> models)
        {
            var admin = _signInManager.UserManager.GetUserId(User);
           
            foreach (var model in models)
            {
                var Attendance = new Attendance()
                {
                    StudentId = model.StudentId,
                    SessionId = model.SessionId,
                    IsAttended = model.IsAttendant,
                    CreatedBy=admin
                };
                _context.Attendances.Add(Attendance);
                _context.SaveChanges();
            }
          //id of the session 
            TempData["id"] = models.Select(s => s.SessionId).FirstOrDefault();
            return RedirectToAction("AttendanceList");
        }
        //AttendenceEditing
        public async Task<IActionResult> AttendenceEditing(int id)
        {
            IEnumerable<Attendance> attendances = await _context.Attendances.Include(s => s.ApplicationUser)
                .Include(s=>s.session).Where(s => s.SessionId == id).ToListAsync();
            if (attendances.Count()!=0)
            {
                List<AttendanceViewModel> models = new List<AttendanceViewModel>();
                foreach (var attendence in attendances)
                {
                    models.Add(new AttendanceViewModel()
                    {
                        Id = attendence.Id,
                        FirstName = attendence.ApplicationUser.FirstName,
                        LastName = attendence.ApplicationUser.LastName,
                        Email = attendence.ApplicationUser.Email,
                        StudentId = attendence.StudentId,
                        SessionId = attendence.SessionId,
                        IsAttendant=attendence.IsAttended,
                        CreatedAt=attendence.CreatedAt, 
                    });     
                }
                ViewBag.SessionName = attendances.Select(s => s.session.Description).FirstOrDefault();
               
                return View(models);
            }
            return RedirectToAction("ErrorPage", "Admin");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AttendenceEditing(List<AttendanceViewModel> models)
        {
            var admin = await _signInManager.UserManager.GetUserAsync(User);

            foreach (var model in models)
            {
                var Attendance = new Attendance()
                {
                    Id=model.Id,
                    StudentId = model.StudentId,
                    SessionId = model.SessionId,
                    IsAttended = model.IsAttendant,
                    CreatedBy = admin.Id,
                    CreatedAt=model.CreatedAt,
                    ModifiedBy = admin.Id,
                    ModifiedAt=DateTime.Now    
                };
                _context.Attendances.Update(Attendance);
                _context.SaveChanges();
            }
            TempData["id"] = models.Select(s => s.SessionId).FirstOrDefault();
            return RedirectToAction("AttendanceList");
        }
        //delete attendance
        public async Task<IActionResult> DeleteAttendance(int id)
        {
           
            var attendance = await _context.Attendances.FindAsync(id);
            TempData["id"] = attendance.SessionId;
            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            return RedirectToAction("AttendanceList");
        }
        //list of attendance
        public async Task<IActionResult> AttendanceList(int _id)
        {
            int id = Convert.ToInt32(TempData["id"]);
            IEnumerable<Attendance> attendances = await _context.Attendances.Include(s => s.ApplicationUser).Include(s=>s.session)
            .Where(s => s.SessionId== id||s.SessionId==_id).ToListAsync();
            if (attendances.Count() != 0)
            {
                List<AttendanceViewModel> models = new List<AttendanceViewModel>();
                foreach (var attendence in attendances)
                {
                    models.Add(new AttendanceViewModel()
                    {
                        FirstName = attendence.ApplicationUser.FirstName,
                        LastName = attendence.ApplicationUser.LastName,
                        Email = attendence.ApplicationUser.Email, 
                        CreatedAt=attendence.CreatedAt,
                        IsAttendant = attendence.IsAttended
                    });
                }
                ViewBag.SessionName = attendances.Select(s => s.session.Description).FirstOrDefault();
                return View(models);
            }
            return RedirectToAction("ErrorPage", "Admin");
        }
        //add assignment
        public async Task<IActionResult> AddAssignment(int id)
        {
            var model = new AssginmentViewModel
            {
                SessionId = id,
            };

            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddAssignment(AssginmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin =await _signInManager.UserManager.GetUserAsync(User);
                await _context.Assignments.AddAsync(new Assigment()
                {
                    Question=model.Question,
                    Material=model.Material,
                    DeadLine=model.DeadLine,
                    Description=model.Description,
                    SessionId= model.SessionId,
                   CreatedBy =admin.Id,
                    
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("success");
            }
            return View(model);
        }
        public async Task<IActionResult> EditAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if(assignment== null)
            {
                string text = "There is no assginment yet";
                return RedirectToAction("ErrorPage", "Admin", new { text });
            }
            var model = new AssginmentViewModel
            {
                Id = assignment.Id,
                Question = assignment.Question,
                Material = assignment.Material,
                DeadLine = assignment.DeadLine,
                Description = assignment.Description,
                SessionId = assignment.SessionId  

            };
            
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditAssignment(AssginmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = await _signInManager.UserManager.GetUserAsync(User);
                var assinment = new Assigment
                {
                    Question = model.Question,
                    Material = model.Material,
                    DeadLine = model.DeadLine,
                    Id = model.Id,
                    SessionId = model.SessionId,
                    CreatedBy=admin.Id
                };
                int sessionid = (int)model.SessionId;
                _context.Assignments.Update(assinment);
                await _context.SaveChangesAsync();
                return RedirectToAction("AssginmentList", new { sessionid });
            }
            return View(model);

        }
        //get assignment answer
        public async Task<IActionResult> GetAnswer(int id)
        {
            int SessionId =id;
            var getanswers = await _context.StudentAssignments.Include(a => a.Assignment)
               .Where(a => a.AssignmentId == a.Assignment.Id&&a.Assignment.SessionId==SessionId)
               .Include(a => a.ApplicationUser).ToListAsync();
            if (getanswers.Count() == 0)
            {
                string text = "There is no answer yet";
                return RedirectToAction("ErrorPage", "Admin", new {text});
            }
            return View(getanswers);
        }
        // list of assignment of specific session
        public async Task<IActionResult> AssginmentList(int sessionid)
        {
            IEnumerable<Assigment> assigments = await _context.Assignments.Include(a=>a.Session).Where(a => a.SessionId == sessionid).ToListAsync();
            if (assigments.Count() == 0)
            {
                string text = "There is no assigments yet";
                return RedirectToAction("ErrorPage", "Admin", new { text });
            }
            ViewBag.SessionName = assigments.Select(s => s.Session.Description).FirstOrDefault();
            var Admin = await _signInManager.UserManager.GetUserAsync(User);
            ViewBag.AdminId = Admin.Id;
            return View(assigments);
        }
        public async Task<IActionResult> CheckAssginment(int AssginmentId,string StudentId)
        {
            var studentAssignment = await _context.StudentAssignments.Where(a => a.AssignmentId == AssginmentId && a.StudentId == StudentId)
                .Include(a=>a.Assignment).SingleOrDefaultAsync();
            if (studentAssignment == null)
            {
                return RedirectToAction("ErrorPage", "Admin");
            }
            var model = new EvaluationViewModel()
            {
                Evaluations = new List<Evaluation>()
                {
                    new Evaluation() { Id = 1, Grade = "Excellet" },
                    new Evaluation() { Id = 2, Grade = "Good" },
                    new Evaluation() { Id = 3, Grade = "Failed" }
                },
                Solution=studentAssignment.Solution,
                StudentId=studentAssignment.StudentId,
                AssginmentId=studentAssignment.AssignmentId   ,
                SessionId=studentAssignment.Assignment.SessionId
                
            };
            return View(model);
        }
        // evaluation assginment
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CheckAssginment(EvaluationViewModel model)
        {
            if (ModelState.IsValid)
            {
                  var studentAssginment = new StudentAssignment()
                  {
                        StudentId = model.StudentId,
                        AssignmentId = model.AssginmentId,
                        Solution = model.Solution,
                        Evaluation = model.SelectedGrade,
                        Comments = model.Comment
                  };
                _context.StudentAssignments.Update(studentAssginment);
                await _context.SaveChangesAsync();

                int? id = model.SessionId;
                return RedirectToAction("GetAnswer", "Admin", new {id});
            }
            return View(model);
        }
        //Evaluation 
        public async Task<IActionResult> Evaluation( string StudentId,int AssignmentId)
        {
            var evaluation = await _context.StudentAssignments.FindAsync(StudentId,AssignmentId);
            if (evaluation == null)
            {

                string text = " Your assignment has not been evaluated";
                return RedirectToAction("ErrorPage", "Admin", new { text });
               
            }
         
            return View(evaluation);
        }
        //error page
        public IActionResult ErrorPage(string text)
        {
            ViewBag.error = text;
            return View();
        }
        public IActionResult success()
        {
            int course_id = Convert.ToInt32(TempData["CourseId"]);
            return View(course_id);
        }
        public void CreateSelectList(int? selecteditem)
        {
           
            IEnumerable<Course> courseList = _context.Courses;
            SelectList listItems = new SelectList(courseList, "Id", "Title", selecteditem);
            ViewBag.CategoryList = listItems;

        }
    }
}
