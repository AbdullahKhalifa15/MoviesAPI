using CancerProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class PatientContactWithHospitalMap
    {
        public PatientContactWithHospitalMap (EntityTypeBuilder<PatientContactWithHospital> entityBuilder)
        {
            entityBuilder.HasKey(p => new { p.PatientId, p.HospitalId });

            //many to many (patient-Hospital)
            entityBuilder.HasOne<Patient>(p=>p.Patient).WithMany(p=>p.patientContactWithHospitals).HasForeignKey(p=>p.PatientId);
            entityBuilder.HasOne<Hospital>(p => p.Hospital).WithMany(p => p.patientContactWithHospitals).HasForeignKey(p => p.HospitalId);

        }

    }
}
