namespace CancerProject.Models
{
    public class Hospital : MedicalTypeBaseEntity
    {
        public string Image { get; set; }

        public ICollection<PatientContactWithHospital> patientContactWithHospitals { get; set; }
    }
}
