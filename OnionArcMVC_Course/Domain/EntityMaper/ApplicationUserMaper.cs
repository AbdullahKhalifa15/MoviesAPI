using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class ApplicationUserMaper
    {
        public ApplicationUserMaper(EntityTypeBuilder<ApplicationUser> entitybulider)
        {
            //one to many(ApplicationaUser-Course)
            entitybulider.HasOne(s => s.Course).WithMany(s => s.ApplicationUsers).HasForeignKey(s => s.CourseId);

        }
    }
}
