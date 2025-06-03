using CancerProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class PatientContactWithDoctorMap
    {
        public PatientContactWithDoctorMap(EntityTypeBuilder<PatientContactWithDoctor> entitybuilder) 
        {
            entitybuilder.HasKey(p => new { p.PatientId, p.DoctorId });

            // many to many (Patient-Doctor)
            entitybuilder.HasOne<Patient>(p=>p.Patient).WithMany(p=>p.patientContactWithDoctors).HasForeignKey(p=>p.PatientId);
            entitybuilder.HasOne<Doctor>(p => p.Doctor).WithMany(p => p.patientContactWithDoctors).HasForeignKey(p => p.DoctorId);

        }
    }
}
