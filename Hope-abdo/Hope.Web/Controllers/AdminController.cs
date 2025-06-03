using CancerProject.Models;
using DomainLayer.Models;
using Hope.Web.Data;
using Hope.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Numerics;
using System.Xml.Linq;

namespace Hope.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AdminController(ApplicationDbContext context , SignInManager<ApplicationUser> signIn)
        {
            _context = context;
            _signInManager = signIn;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //add new doctor
        public IActionResult Doctor(DoctorViewModel model) 
        {
            if (ModelState.IsValid)
            {
                // get id of admin 
                var admin = _signInManager.UserManager.GetUserId(User);
                var doctor = new Doctor()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Specialty=model.Specialty,
                    MobileNumber = model.MobileNumber,
                    MoreInformation = model.MoreInformation,
                    Address = model.Address,
                    FB_Link = model.FB_Link,
                    TW_Link = model.TW_Link,
                    CreatedBy=admin
                };
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("Index", "DashBoard");
            }
            return View(model);
        }
        public IActionResult EditDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            var model = new DoctorViewModel
            {   
                Id=doctor.Id,
                Name = doctor.Name,
                Email = doctor.Email,
                Specialty = doctor.Specialty,
                MobileNumber = doctor.MobileNumber,
                MoreInformation = doctor.MoreInformation,
                Address = doctor.Address,
                FB_Link = doctor.FB_Link,
                TW_Link = doctor.TW_Link,
            };
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditDoctor(DoctorViewModel model)
        {   
            if (ModelState.IsValid)
            {
                var admin = _signInManager.UserManager.GetUserId(User);
                var doctor = new Doctor
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Specialty = model.Specialty,
                    MobileNumber = model.MobileNumber,
                    MoreInformation = model.MoreInformation,
                    Address = model.Address,
                    FB_Link = model.FB_Link,
                    TW_Link = model.TW_Link,
                    CreatedBy = admin
                };
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
                return RedirectToAction("Doctor", "DashBoard");
            }
            return View(model);
        }
        // delete doctor 
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction("Doctor", "DashBoard");
        }
        //add new hospital
        public IActionResult Hospital()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //add new hospital
        public IActionResult Hospital(HospitalViewModel model) 
        {
            if (ModelState.IsValid)
            {
                // get id of admin 
                var admin = _signInManager.UserManager.GetUserId(User);
                var hospital = new Hospital()
                {
                    Name = model.Name,
                    Address = model.Address,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    MoreInformation = model.MoreInformation,
                    FB_Link = model.FB_Link,
                    TW_Link = model.TW_Link,
                    CreatedBy = admin

                };
                _context.Hospitals.Add(hospital);
                _context.SaveChanges();
                return RedirectToAction("Index", "DashBoard");
            }
            return View(model);

        }
        public IActionResult EditHospital(int id)
        {
            var hospital = _context.Hospitals.Find(id);
            var model = new HospitalViewModel
            {
                Id=hospital.Id,
                Name = hospital.Name,
                Address = hospital.Address,
                Email = hospital.Email,
                MobileNumber = hospital.MobileNumber,
                MoreInformation = hospital.MoreInformation,
                FB_Link = hospital.FB_Link,
                TW_Link = hospital.TW_Link,

            };
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditHospital(HospitalViewModel model)
        {
            var admin = _signInManager.UserManager.GetUserId(User);
           
            if (ModelState.IsValid)
            {
                var hospital = new Hospital()
                {
                    Id= model.Id,
                    Name = model.Name,
                    Address = model.Address,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    MoreInformation = model.MoreInformation,
                    FB_Link = model.FB_Link,
                    TW_Link = model.TW_Link,
                    CreatedBy = admin
                };
                _context.Hospitals.Update(hospital);
                _context.SaveChanges();
                return RedirectToAction("Hospital", "DashBoard");

            }
            return View(model);
        }
        // delete doctor 
        public IActionResult DeleteHospital(int id)
        {
            var hospital = _context.Hospitals.Find(id);
            _context.Hospitals.Remove(hospital);
            _context.SaveChanges();
            return RedirectToAction("Hospital", "DashBoard");
        }
        // add pharmacy
        public IActionResult Pharmacy()
        {

            return View();
        }
        //add pharmacy
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Pharmacy(PharmacyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pharmacy = new Pharmacy()
                {
                    Name = model.Name,
                    UserName = new EmailAddressAttribute().IsValid(model.Email) ? new MailAddress(model.Email).User : model.Email,
                    Email = model.Email,
                    Password = "pharmacy",
                    Address = model.Location,
                    MobileNumber = model.PhoneNumber,
                    AdditionalInformation = model.AdditionalInfo,
                    FB_Link = model.FB_Link,
                    TW_Link = model.TW_Link,
                };
                _context.Pharmacies.Add(pharmacy);
                _context.SaveChanges();
                return RedirectToAction("Index", "DashBoard");

            }
            
            return View(model);
        }
        //add blog
        public IActionResult Blog()
        {
            return View();
        }
        //add blog
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Blog(AwarenessViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _signInManager.UserManager.GetUserId(User);

                var awareness = new Awareness()
                {
                    Title = model.Title,
                    Data = model.Data,
                    Author = model.Author,
                    Videos = model.VideoLink,
                    PublishedDate = model.PublishedDate,
                    Category = model.Category,
                    CreatedBy = admin

                };
                _context.Awarenesses.Add(awareness);
                _context.SaveChanges();
                return RedirectToAction("Index", "DashBoard");
            }

            return View(model);
        }
        //edit blog 
        public IActionResult EditBlog(int id)
        {
            var blog = _context.Awarenesses.Find(id);
            var model = new AwarenessViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Data = blog.Data,
                Author = blog.Author,
                PublishedDate = blog.PublishedDate,
                Category = blog.Category,
                VideoLink = blog.Videos,
            };
            return View(model);
        }
        //edit blog
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditBlog(AwarenessViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _signInManager.UserManager.GetUserId(User);
                var blog = new Awareness
                {
                    Title = model.Title,
                    Data = model.Data,
                    Author = model.Author,
                    Videos = model.VideoLink,
                    PublishedDate = model.PublishedDate,
                    Category = model.Category,
                    CreatedBy = admin
                };
                _context.Awarenesses.Update(blog);
                _context.SaveChanges();
                return RedirectToAction("Blog", "DashBoard");
            }

            return View(model);
        }
        // delete doctor 
        public IActionResult DeleteBlog(int id)
        {
            var blog = _context.Awarenesses.Find(id);
            _context.Awarenesses.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Blog", "DashBoard");
        }
        //add charity
        public IActionResult Charity()
        {
            return View();
        }
        //add charity
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Charity(CharityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _signInManager.UserManager.GetUserId(User);
                var charity = new Charities()
                {

                    Name = model.Name,
                    Email = model.Email,
                    MobileNumber = model.PhoneNumber,
                    Address = model.Location,
                    MoreInformation = model.AdditionalInfo,
                    FB_Link = model.FB_Link,
                    TW_Link = model.TW_Link,
                    CreatedBy =admin
                };
                _context.Charities.Add(charity);
                _context.SaveChanges();
                return RedirectToAction("Index", "DashBoard");
            }
            
            return View(model);
        }
        //Edit Charity
        public IActionResult EditCharity(int id )
        {
            var charity = _context.Charities.Find(id);
            var model = new CharityViewModel
            {
                Id = charity.Id,
                Name = charity.Name,
                Email = charity.Email,
                PhoneNumber = charity.MobileNumber,
                Location = charity.Address,
                AdditionalInfo = charity.MoreInformation,
                FB_Link = charity.FB_Link,
                TW_Link = charity.TW_Link

            };
            return View(model);
        }
        //Edit Charity
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditCharity(CharityViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                var admin = _signInManager.UserManager.GetUserId(User);
                var charity = new Charities()
                {

                    Name = model.Name,
                    Email = model.Email,
                    MobileNumber = model.PhoneNumber,
                    Address = model.Location,
                    MoreInformation = model.AdditionalInfo,
                    FB_Link = model.FB_Link,
                    TW_Link = model.TW_Link,
                    CreatedBy = admin
                };
                _context.Charities.Update(charity);
                _context.SaveChanges();
                return RedirectToAction("Charity", "DashBoard");
            }
            return View(model);
        }
        public IActionResult DeleteCharity(int id)
        {
            var charity = _context.Charities.Find(id);
            _context.Charities.Remove(charity);
            _context.SaveChanges();
            return RedirectToAction("Charity", "DashBoard");
        }
    }
}
