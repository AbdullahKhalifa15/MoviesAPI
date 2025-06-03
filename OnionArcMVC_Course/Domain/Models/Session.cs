using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
       public class Session : BaseEntity
       {
            [Required]
           public DateTime Date { get; set; }
            [Required]
           public string Description { get; set; }
            [Required]
            public string Material { get; set; }
            public int? CourseId { get; set; }
            //public int? AttendenceId { get; set; }
           
            //nav prop 
            public Course Course { get; set; }
            public ICollection<Assigment> Assignments { get; set; }
            public ICollection<Attendance> Attentances { get; set; }
       }
}
