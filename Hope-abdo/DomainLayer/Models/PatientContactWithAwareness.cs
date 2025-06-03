using CancerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PatientContactWithAwareness
    {
        public int PatientId { get; set; }
        public int AwarenessId { get; set; }

        public  Patient Patient { get; set; }
        public Awareness Awareness { get; set;}
    }
}
