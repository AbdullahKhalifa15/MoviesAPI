using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class StudentAssignment
    {
        public string StudentId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int AssignmentId { get; set; }
        public Assigment Assignment { get; set; }

        [Required]
        public string Solution { get; set; }
        public string Evaluation { get; set; }
        public string Comments { get; set; }
       



    }
}
