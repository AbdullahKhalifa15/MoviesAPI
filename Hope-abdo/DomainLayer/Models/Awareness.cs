using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Awareness
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Title Must be More Than 2 Characters.")]
        public string Title { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Data Must be More Than 2 Characters.")]
        public string Data { get; set; }
        [Required(ErrorMessage = "You must enter PublishedDate.")]
        public DateTime PublishedDate { get; set; }
        [Required(ErrorMessage = "You must enter Author Name.")]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
        public string Image { get; set; }
        public string Videos { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<PatientContactWithAwareness> patientContactWithAwarenesses { get; set; }
    }
}
