using CancerProject.Models;
using Hope.Web.Data;
using Hope.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Hope.Web.Controllers
{
   
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            string user_id = _signInManager.UserManager.GetUserId(User);
            var user = _context.Users.Find(user_id);
            return View(user);
        }
        public async Task<IActionResult> Edit()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var model = new UserProfileUpdateViewModel()
            {
                FirstName = user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                Gender= user.Gender,
                phoneNumber=user.PhoneNumber
            };

            ViewBag.username = user.UserName;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserProfileUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                 await _userManager.ChangePasswordAsync(user,model.OldPassword, model.NewPassword);
                user.FirstName = model.FirstName; 
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = new MailAddress(model.Email).User;
                user.Address = model.Address;
                user.Gender = model.Gender;
                user.PhoneNumber = model.phoneNumber;
                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        // layout  of view profile
        public IActionResult viewprofile()
        {
            return View();
        }
    }
}