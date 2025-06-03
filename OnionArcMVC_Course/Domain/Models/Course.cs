using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DomainLayer.Models
{
    public class Course : BaseEntity
    {

        [Required]
        [MinLength(2, ErrorMessage = " Course Title should be more than 1 character!")]
        public string Title { get; set; }
        public string Appointment { get; set; }
        [Required]
        public string Details { get; set; }
        public string Image { get; set; }

        // nav prop
        public ICollection<Session> Sessions { get; set; }
       public  ICollection<ApplicationUser> ApplicationUsers { get; set; }


    }
}
