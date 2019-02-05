using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.Property(c => c.Email)
                   .HasMaxLength(80)
                   .IsUnicode(false);

            builder.HasMany(c => c.Sales)
                   .WithOne(s => s.Customer)
                   .HasForeignKey(s => s.CustomerId);
        }
    }
}
