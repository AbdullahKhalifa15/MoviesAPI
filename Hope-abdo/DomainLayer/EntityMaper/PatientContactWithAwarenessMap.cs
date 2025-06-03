using CancerProject.Models;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class PatientContactWithAwarenessMap
    {
        public PatientContactWithAwarenessMap(EntityTypeBuilder<PatientContactWithAwareness> entityBuilder) 
        {
            entityBuilder.HasKey(p => new { p.PatientId, p.AwarenessId });

            //many to many (patient-Awareness)
            entityBuilder.HasOne<Patient>(p => p.Patient).WithMany(p => p.patientContactWithAwarenesses).HasForeignKey(p => p.PatientId);
            entityBuilder.HasOne<Awareness>(p => p.Awareness).WithMany(p => p.patientContactWithAwarenesses).HasForeignKey(p => p.AwarenessId);
        }
    }
}
