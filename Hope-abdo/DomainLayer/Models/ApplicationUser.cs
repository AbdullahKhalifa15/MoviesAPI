using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CancerProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
       
        public string Gender { get; set; }
        public string TypeOfCancer { get; set; }
        public string Address { get; set; }

    }
}