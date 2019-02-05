using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using P01_StudentSystem.Data.Models.Enums;
using System;

namespace P01_StudentSystem.Data.EntityConfigurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(h => h.HomeworkId);

            builder.Property(h => h.Content)
                   .IsUnicode();

            builder.Property(h => h.ContentType)
                   .HasConversion(v => v.ToString(),
                                  v => (ContentType)Enum.Parse(typeof(ContentType), v));
        }
    }
}
