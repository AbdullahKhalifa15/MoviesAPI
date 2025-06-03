using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hope.Web.ViewModels
{
    public class PharmacyRegisterViewModel
    {
        [Required(ErrorMessage ="please enter pharmacy name.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string PharmacyName { get; set; }
        [Required(ErrorMessage = "please enter your email.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="please enter your password.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }

    }
}
