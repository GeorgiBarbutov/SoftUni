using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(s => s.Name)
                   .HasMaxLength(80)
                   .IsUnicode();

            builder.HasMany(p => p.Sales)
                   .WithOne(s => s.Store)
                   .HasForeignKey(s => s.StoreId);
        }
    }
}
