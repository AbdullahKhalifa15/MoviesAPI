using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public abstract class MedicalTypeBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Name Must be More Than 2 Characters.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Address must be more than 5 words")]
        public string Address { get; set; }
        [MinLength(10)]
        public string MoreInformation { get; set; }
        [MinLength(10, ErrorMessage = "Link must be more than 10 words")]
        public string FB_Link { get; set; }
        [MinLength(10, ErrorMessage = "Link must be more than 10 words")]
        public string TW_Link { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
