using CancerProject.Models;
using DomainLayer.EntityMaper;
using DomainLayer.Models;
using Hope.Web.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hope.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PatientContactWithAwarenessMap(modelBuilder.Entity<PatientContactWithAwareness>());
            new PatientContactWithCharitiesMap(modelBuilder.Entity<PatientContactWithCharities>());
            new PatientContactWithDoctorMap(modelBuilder.Entity<PatientContactWithDoctor>());
            new PatientContactWithHospitalMap(modelBuilder.Entity<PatientContactWithHospital>());
            new PharmacyExistDrugsMap(modelBuilder.Entity<PharmacyExistDrugs>());
            new PatientOrderDrugsMap(modelBuilder.Entity<PatientOrderDrugs>());
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Charities> Charities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Drugs> Drugs { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Awareness> Awarenesses { get; set; }
    }
    
}