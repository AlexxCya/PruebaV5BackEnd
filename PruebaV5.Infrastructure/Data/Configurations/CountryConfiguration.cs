using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaV5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Infrastructure.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Alpha2Code)
                .IsRequired()
                .HasColumnName("alpha2Code")
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.Alpha3Code)
                .IsRequired()
                .HasColumnName("alpha3Code")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.ImageUrl)
                .HasColumnName("imageUrl")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Independent).HasColumnName("independent");

            entity.Property(e => e.Iso)
                .IsRequired()
                .HasColumnName("iso")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsUnicode(false);
        }
    }
}
