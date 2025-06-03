using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OionArcMVC.ViewModel
{
    public class EditProfile
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string oldPassword { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public IFormFile ClientFile { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        public string ImageSrc { get; set; }



    }
}
