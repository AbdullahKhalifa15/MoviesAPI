using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class StudentAssignmentMaper
    {
        public StudentAssignmentMaper(EntityTypeBuilder<StudentAssignment> entityBuilder)
        {
            entityBuilder.HasKey(pc => new { pc.StudentId, pc.AssignmentId });
            
            // many to many (student-Assignment)
            entityBuilder.HasOne(t => t.ApplicationUser).WithMany(u => u.StudentAssignments).HasForeignKey(x => x.StudentId);
            entityBuilder.HasOne(t => t.Assignment).WithMany(u => u.StudentAssignments).HasForeignKey(x => x.AssignmentId);

        }
    }
}