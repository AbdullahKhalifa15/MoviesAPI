using System.ComponentModel.DataAnnotations;

namespace Hope.Web.ViewModels
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }
        [Required, MaxLength(100, ErrorMessage ="The firstName must be more than 2"),MinLength(2)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string TypeOfCancer { get; set; }

    }
}
