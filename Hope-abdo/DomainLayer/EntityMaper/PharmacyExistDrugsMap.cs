using CancerProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMaper
{
    public class PharmacyExistDrugsMap
    {
       public PharmacyExistDrugsMap(EntityTypeBuilder<PharmacyExistDrugs> entitybuilder)
       {
            entitybuilder.HasKey(pc => new { pc.PharmacyId, pc.DrugsId });

            // many to many (Pharmacy-Drugs)
            entitybuilder.HasOne<Pharmacy>(t => t.Pharmacy).WithMany(u => u.PharmacyExistDrugs).HasForeignKey(x => x.PharmacyId);
            entitybuilder.HasOne<Drugs>(t => t.Drugs).WithMany(u => u.PharmacyExistDrugs).HasForeignKey(x => x.DrugsId);
        }
    }
}
