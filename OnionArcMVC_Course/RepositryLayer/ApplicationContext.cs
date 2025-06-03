using DomainLayer;
using DomainLayer.EntityMaper;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryLayer
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;
        public ApplicationContext(DbContextOptions options) : base(options)
        {
          _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AssignmentMaper(modelBuilder.Entity<Assigment>());
            new AttendanceMaper(modelBuilder.Entity<Attendance>());
            new SessionMaper(modelBuilder.Entity<Session>());
            new StudentAssignmentMaper(modelBuilder.Entity<StudentAssignment>());
            new ApplicationUserMaper(modelBuilder.Entity<ApplicationUser>());
        }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Assigment> Assignments { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }

    }

}
