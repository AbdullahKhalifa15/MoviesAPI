namespace CancerProject.Models
{
    public class PatientContactWithCharities
    {
        public int PatientId { get; set; }
       public int CharitiesId { get; set; } 
        public Patient Patient { get; set; }
        public Charities Charities { get; set; }    
    }
}
