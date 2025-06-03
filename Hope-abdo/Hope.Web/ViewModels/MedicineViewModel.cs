using System.ComponentModel.DataAnnotations;

namespace Hope.Web.ViewModels
{
    public class MedicineViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Name must be more than 2 character.")]
        public string Name { get; set; }
        public string TypeOfCancer { get; set; }
        
    }
}
