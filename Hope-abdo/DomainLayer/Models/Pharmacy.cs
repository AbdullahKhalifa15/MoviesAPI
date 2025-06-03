using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public class Pharmacy : UserBaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Address { get; set; }
        [MinLength(10)]
        public string FB_Link { get; set; }
        [MinLength(10)]
        public string TW_Link { get; set; }
     
        public string AdditionalInformation { get; set; }
       

        public ICollection< PharmacyExistDrugs> PharmacyExistDrugs { get; set; }
    }
}
