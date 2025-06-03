using CancerProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PatientOrderDrugs
    {
        public int PatientId { get; set; }
        public int DrugsId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime TimeEachMonth { get; set; } 

        public Patient Patient { get; set; }
        public Drugs Drugs { get; set; }

    }
}
