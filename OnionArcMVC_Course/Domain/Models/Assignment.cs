using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Assigment: BaseEntity
    {
        [Required]
        public DateTime  DeadLine { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string Question { get; set; }
        public string Description { get; set; }
        public int? SessionId { get; set; }
        
        //nav prop
        public Session Session { get; set; }
         public ICollection<StudentAssignment> StudentAssignments { get; set; }

    }
}
