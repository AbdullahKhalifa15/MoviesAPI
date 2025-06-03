using DomainLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public class Patient : UserBaseEntity
    {
        [Required]
        public string TypeOfCancer { get; set; }
        public ICollection<PatientOrderDrugs> patientOrderDrugs { get; set; }
        public ICollection<PatientContactWithDoctor> patientContactWithDoctors { get; set; }
        public ICollection<PatientContactWithHospital> patientContactWithHospitals { get; set; }
        public ICollection<PatientContactWithCharities> patientContactWithCharities { get; set; }
        public ICollection<PatientContactWithAwareness> patientContactWithAwarenesses { get; set; }
    }
}
