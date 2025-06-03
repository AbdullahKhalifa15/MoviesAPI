using System.ComponentModel.DataAnnotations;

namespace Hope.Web.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Name Must be More Than 2 Characters.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "The Specialty  Must be More Than 5 Characters.")]
        public string Specialty { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Address must be more than 5 words")]
        public string Address { get; set; }
        [MinLength(10, ErrorMessage = "Additional information must be more than 10 words")]
        public string MoreInformation { get; set; }
        [MinLength(10, ErrorMessage = "Facebook link must be more than 10 words")]
        public string FB_Link { get; set; }
        [MinLength(10, ErrorMessage = "Twetter link must be more than 10 words")]
        public string TW_Link { get; set; }

    }
}
