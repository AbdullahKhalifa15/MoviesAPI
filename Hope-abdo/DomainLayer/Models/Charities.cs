using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public class Charities : MedicalTypeBaseEntity
    {
         public string Image { get; set; }
        public ICollection<PatientContactWithCharities> patientContactWithCharities { get; set; }
    }
}
