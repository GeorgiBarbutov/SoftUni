using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.Property(s => s.PhoneNumber)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .IsRequired(false);

            builder.Property(s => s.Birthday)
                   .IsRequired(false);

            builder.HasMany(s => s.CourseEnrollments)
                   .WithOne(sc => sc.Student)
                   .HasForeignKey(sc => sc.StudentId);

            builder.HasMany(s => s.HomeworkSubmissions)
                   .WithOne(h => h.Student)
                   .HasForeignKey(h => h.StudentId);
        }
    }
}
