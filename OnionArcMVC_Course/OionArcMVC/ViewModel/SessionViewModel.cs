using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace OionArcMVC.ViewModel
{
    public class SessionViewModel
    {
        
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime Date { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Material { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Choose Your Course")]
        public int? CourseId { get; set; }
        public int? AttendenceId { get; set; }
    }
}
