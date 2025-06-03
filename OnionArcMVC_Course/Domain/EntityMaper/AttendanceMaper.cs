using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class AttendanceMaper
    {
        public AttendanceMaper(EntityTypeBuilder<Attendance> entitybuilder) 
        {
            // one to many (Student(Application User) - Attendence)
            entitybuilder.HasOne(s=>s.ApplicationUser).WithMany(s=>s.Attendances).HasForeignKey(s=>s.StudentId);
        }
    }
}
