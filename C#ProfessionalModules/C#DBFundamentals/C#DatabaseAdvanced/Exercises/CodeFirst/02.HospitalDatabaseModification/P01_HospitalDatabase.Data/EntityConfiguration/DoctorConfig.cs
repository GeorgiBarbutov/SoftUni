﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.Property(p => p.Specialty)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.HasMany(d => d.Visitations)
                   .WithOne(v => v.Doctor)
                   .HasForeignKey(v => v.DoctorId);
        }
    }
}
