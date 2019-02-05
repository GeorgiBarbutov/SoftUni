using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.HasMany(m => m.Prescriptions)
                   .WithOne(p => p.Medicament)
                   .HasForeignKey(p => p.MedicamentId);
        }
    }
}
