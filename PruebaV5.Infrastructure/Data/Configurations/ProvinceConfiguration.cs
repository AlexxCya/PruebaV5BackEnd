using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaV5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Infrastructure.Data.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Abbrevation)
                .IsRequired()
                .HasColumnName("abbrevation")
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.CountyId).HasColumnName("countyId");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.County)
                .WithMany(p => p.Province)
                .HasForeignKey(d => d.CountyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Province_Country");
        }
    }
}
