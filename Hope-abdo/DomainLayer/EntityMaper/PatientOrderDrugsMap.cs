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
    public class PatientOrderDrugsMap
    {
        public PatientOrderDrugsMap(EntityTypeBuilder<PatientOrderDrugs> typeBuilder)
        {
            typeBuilder.HasKey(p => new { p.PatientId, p.DrugsId });

            //many to many (patient-Drugs)
            typeBuilder.HasOne<Patient>(p => p.Patient).WithMany(p => p.patientOrderDrugs).HasForeignKey(p => p.PatientId);
            typeBuilder.HasOne<Drugs>(p => p.Drugs).WithMany(p => p.patientOrderDrugs).HasForeignKey(p => p.DrugsId);
        }
    }
}
