using DomainLayer.Models;
using Foolproof;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionArchitectureMVC.ViewModel
{
    public class RegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string PhoneNumber { get; set; }
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Choose Your Course")]
        public int  CourseId { get; set; }
        public bool InActive { get; set; }


    }
}
