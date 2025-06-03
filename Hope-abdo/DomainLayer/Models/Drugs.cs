using DomainLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public class Drugs
    {
        [Key]
        public int Id { get; set; }
        [Required]
       [MinLength(2,ErrorMessage ="The Name must be more than 2 character.")]
        public string Name { get; set; }
        public string TypeOfCancer { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Image { get; set; }
        public ICollection<PatientOrderDrugs> patientOrderDrugs { get; set; }
        public ICollection<PharmacyExistDrugs> PharmacyExistDrugs { get; set; }
    }
}
