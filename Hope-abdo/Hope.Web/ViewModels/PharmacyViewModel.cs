using System.ComponentModel.DataAnnotations;

namespace Hope.Web.ViewModels
{
    public class PharmacyViewModel
    {
        [Required]
        [MinLength(2,ErrorMessage ="The Name Must be More Than 2 Characters.")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Address Must be More Than 2 Characters.")]
        public string Location { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string AdditionalInfo { get; set;}
        [MinLength(10, ErrorMessage = "Facebook link must be more than 10 words")]
        public string FB_Link { get; set; }
        [MinLength(10, ErrorMessage = "Twetter link must be more than 10 words")]
        public string TW_Link { get; set; }
    }
}
