
using System.ComponentModel.DataAnnotations;

namespace Hope.Web.ViewModels
{
    public class CharityViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="The Name must be more than 2 character.")]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Address must be more than 5 words")]
        public string Location { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string AdditionalInfo { get; set; }
        public string FB_Link { get; set; }
        public string TW_Link { get; set; }






    }
}
