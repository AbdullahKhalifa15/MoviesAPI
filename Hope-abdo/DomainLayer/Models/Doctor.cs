using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public class Doctor : MedicalTypeBaseEntity
    {
        [Required]
        [MinLength(5, ErrorMessage = "The Specialty  Must be More Than 5 Characters.")]
        public string Specialty { get; set; }
        public string Image { get; set; }
        public ICollection<PatientContactWithDoctor> patientContactWithDoctors { get; set; }
    }
}
