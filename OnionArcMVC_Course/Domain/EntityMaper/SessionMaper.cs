using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class SessionMaper
    {
        public SessionMaper(EntityTypeBuilder<Session> entitybulider) 
        {
            // one to many (Course-Session)
            entitybulider.HasOne(s=>s.Course).WithMany(s => s.Sessions).HasForeignKey(s=>s.CourseId);
            // one to many (session - Attendance)
            entitybulider.HasMany(s=>s.Attentances).WithOne(s=>s.session).HasForeignKey(s=>s.SessionId);
        }
    }
}
