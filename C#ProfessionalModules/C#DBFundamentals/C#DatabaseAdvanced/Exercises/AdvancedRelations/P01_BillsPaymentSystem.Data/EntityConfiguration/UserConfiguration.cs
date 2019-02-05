using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                   .IsUnicode();

            builder.Property(u => u.LastName)
                   .IsUnicode();

            builder.Property(u => u.Email)
                   .IsUnicode(false);

            builder.Property(u => u.Password)
                   .IsUnicode(false);

            builder.HasMany(u => u.PaymentMethods)
                   .WithOne(pm => pm.User)
                   .HasForeignKey(pm => pm.UserId);
        }
    }
}
