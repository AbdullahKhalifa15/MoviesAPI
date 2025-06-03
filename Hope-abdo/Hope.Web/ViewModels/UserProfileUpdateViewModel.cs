using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hope.Web.ViewModels
{
    public class UserProfileUpdateViewModel
    {
        [Required(ErrorMessage = "please enter first name.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "please enter last name.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "please enter your email.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "please enter your old password.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "please enter your password.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "new Password and confirmation new password not match.")]
        public string ConfirmNewPassword { get; set; }
        public string Address { get; set; }
        public string phoneNumber { get; set; }
        public string Gender { get; set; }

    }
}
