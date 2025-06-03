using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Attendance :BaseEntity
    {
        public string StudentId { get; set; }
       public bool IsAttended { get; set; } = true;
        public int SessionId { get; set; }
        //nav prop 
        public ApplicationUser ApplicationUser { get; set; }
         public Session session { get; set; }



    }
}
