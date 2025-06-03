namespace CancerProject.Models
{
    public class PatientContactWithDoctor
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}
