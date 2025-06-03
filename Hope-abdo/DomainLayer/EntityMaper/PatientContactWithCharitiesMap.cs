using CancerProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class PatientContactWithCharitiesMap
    {
        public PatientContactWithCharitiesMap(EntityTypeBuilder<PatientContactWithCharities> entitybuilder) 
        {
            entitybuilder.HasKey(p => new { p.PatientId, p.CharitiesId });
            
            //Many to Many (patient-Charities)
            entitybuilder.HasOne<Patient>( p=> p.Patient).WithMany(p=>p.patientContactWithCharities).HasForeignKey(p=>p.PatientId);
            entitybuilder.HasOne<Charities>(p => p.Charities).WithMany(p => p.patientContactWithCharities).HasForeignKey(p => p.CharitiesId);
        }
    }
}
