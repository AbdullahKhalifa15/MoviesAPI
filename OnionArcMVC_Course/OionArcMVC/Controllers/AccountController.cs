using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OionArcMVC.Controllers;
using OionArcMVC.ViewModel;
using OnionArchitectureMVC.ViewModel;
using ServiceLayer.CourseService;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Security.Cryptography.Xml;
using System.Text;

namespace OnionArchitectureMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICourseService _context;

        public AccountController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager , ICourseService context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
       
       
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> Register()
        {
           CreateSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = new MailAddress(model.Email).User,//bebo12@gmail.com//user name بياخد من قبل ال @ ويعتبره  
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber=model.PhoneNumber,
                    CourseId = model.CourseId

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
             
                if (ModelState.IsValid)
                {
                    var username = new EmailAddressAttribute().IsValid(user.Email) ? new MailAddress(user.Email).User : user.Email;

                    var result = await _signInManager.PasswordSignInAsync(username, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                    {
                       return RedirectToAction("Index", "course");
                    }
                }
       
            ModelState.AddModelError(string.Empty, "Email or Password were incorrect. Please try again.");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index","Home");
        }
       
        public void CreateSelectList()
        {

            IEnumerable<Course> courseList = _context.GetCourses();
            SelectList listItems = new SelectList(courseList, "Id", "Title");
            ViewBag.CategoryList = listItems;

        }
        public async Task<IActionResult> ViewProfile()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var model = new EditProfile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                ImageSrc = user.ImageSrc,

            };
            return View(model);
        }
        public async Task<IActionResult> EditProfile()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var model = new EditProfile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone=user.Phone,
                ImageSrc=user.ImageSrc,

            };
            return View(model);
          
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditProfile(EditProfile model)
        {
           if (ModelState.IsValid)
           {   
                   var user = await _userManager.GetUserAsync(User);
                   await _userManager.ChangePasswordAsync(user, model.oldPassword, model.NewPassword);
                   user.FirstName = model.FirstName;
                   user.LastName = model.LastName;
                   user.Email = model.Email;
                   user.UserName = new MailAddress(model.Email).User;   
                   user.Phone = model.Phone;
                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);

                // profile picture
                if(model.ClientFile!=null)
                {
                    MemoryStream stream = new MemoryStream();
                    model.ClientFile.CopyTo(stream);
                    user.ProfilePicture = stream.ToArray();
                    _context.SaveChanges();
                }
              
                return   RedirectToAction("ViewProfile");
            };
           
            return View(model);
        }
          

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        public void CreateSelectList(int? selecteditem)
        {
            IEnumerable<Course> courses = _context.GetCourses();
            SelectList listItems = new SelectList(courses, "Id", "Title", selecteditem);
            ViewBag.SelectedList = listItems;
                
        }
        public static string DecryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }
            else
            {
                byte[] encryptedPassword = Convert.FromBase64String(password);
                string decryptedPassword = ASCIIEncoding.ASCII.GetString(encryptedPassword);
                return decryptedPassword;
            }
        }
      
    }
}
