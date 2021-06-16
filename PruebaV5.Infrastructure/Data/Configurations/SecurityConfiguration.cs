using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaV5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Pwd)
                .IsRequired()
                .HasColumnName("pwd")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Role)
                .IsRequired()
                .HasColumnName("role")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.User)
                .IsRequired()
                .HasColumnName("user")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasColumnName("userName")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
