using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    public class DiagnoseConfig : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.Property(p => p.Comments)
                   .HasMaxLength(250)
                   .IsUnicode();
        }
    }
}
