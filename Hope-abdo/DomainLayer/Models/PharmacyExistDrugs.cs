namespace CancerProject.Models
{
    public class PharmacyExistDrugs
    {
        public int PharmacyId { get; set; }
        public int DrugsId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public Drugs Drugs { get; set; }

    }
}
