
using CancerProject.Models;
using Hope.Web.Data;
using Hope.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace Hope.Web.Controllers
{
    [Authorize]
    public class PharmacyActionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly SignInManager<ApplicationUser> _signInManager;
        public PharmacyActionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //pharmacy view profile
        public IActionResult Index()
        {
            var user_id = _signInManager.UserManager.GetUserId(User);
            var user = _context.Users.Find(user_id);
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task< IActionResult> Register(PharmacyRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = new MailAddress(model.Email).User,
                    Email = model.Email,
                    FirstName = model.PharmacyName,
                    LastName = "pharmacy",
                    EmailConfirmed = true
                };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Pharmacy");
                    //  await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("/Home/index");

                }
                ModelState.AddModelError(string.Empty, "Invalid Register Attempt");
            }
            return View(model);
        }
        //view edit pharmacy profile
        public async Task<IActionResult> Edit()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var model = new ProfileUpdateViewModel()
            {
                PharmacyName = user.FirstName,
                Email = user.Email,
                phoneNumber = user.PhoneNumber,
                Address=user.Address
                
            };

            ViewBag.username = user.UserName;
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(ProfileUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                var result = await _userManager.ChangePasswordAsync(user,model.OldPassword,model.NewPassword);
                user.FirstName= model.PharmacyName;
                user.Email= model.Email;
                user.UserName=new MailAddress(model.Email).User;
                user.Address=model.Address;
                user.PhoneNumber = model.phoneNumber;
                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Medicines()
        {
            var medicine = _context.Drugs.ToList();
            return View(medicine);
        }
        public IActionResult AddMedicines()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddMedicines(MedicineViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin=_signInManager.UserManager.GetUserId(User);
                var drug = new Drugs
                {
                    Name = model.Name,
                    TypeOfCancer = model.TypeOfCancer,
                    CreatedBy=admin,
                };
                 await _context.Drugs.AddAsync(drug);
                 await _context.SaveChangesAsync();
               return   RedirectToAction("Medicines");
            }

            return View(model);
        }
        public async Task<IActionResult> EditMedicine(int id)
        {

            var drug = await _context.Drugs.FindAsync(id);
            var medicine = new MedicineViewModel
            {
                Id = id,
                Name = drug.Name,
                TypeOfCancer = drug.TypeOfCancer,
            };
            
            return View(medicine);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditMedicine(MedicineViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _signInManager.UserManager.GetUserId(User);
                var drug = new Drugs
                {
                    Id=model.Id,
                    Name = model.Name,
                    TypeOfCancer = model.TypeOfCancer,
                    CreatedBy = admin
                };
                 _context.Drugs.Update(drug);
                 _context.SaveChanges();
              return   RedirectToAction("Medicines");
            }

            return View(model);
        }
        public IActionResult DeleteMedicine(int id)
        {

              var drug = _context.Drugs.Find(id);
             _context.Drugs.Remove(drug);
             _context.SaveChanges();
           return  RedirectToAction("Medicines");
        }



        // pharmacy order
        public IActionResult Order()
        {
            return View();
        }
        // view liked artical
        public IActionResult Liked()
        {
            return View();
        }
        // view saved artical
        public IActionResult SavedArtical()
        {
            return View();
        }

    }
}
