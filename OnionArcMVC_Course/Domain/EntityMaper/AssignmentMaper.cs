using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class AssignmentMaper
    {
        public AssignmentMaper(EntityTypeBuilder<Assigment> entitybulider) 
        {
            //one to many(Session-Assignment)
            entitybulider.HasOne(s => s.Session).WithMany(s => s.Assignments).HasForeignKey(s => s.SessionId);      
        }
    }
}
