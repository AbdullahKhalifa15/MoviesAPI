namespace CancerProject.Models
{
    public class PatientContactWithHospital
    {
      
        public int PatientId { get; set; }
        public int HospitalId { get; set; }
        public Patient Patient { get; set; }
        public Hospital Hospital { get; set; }

    }
}
