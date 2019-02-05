using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfiguration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(ba => ba.BankName)
                   .IsUnicode();

            builder.Property(ba => ba.SWIFTCode)
                   .IsUnicode(false);

            builder.HasOne(ba => ba.PaymentMethod)
                   .WithOne(pm => pm.BankAccount)
                   .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId);
        }
    }
}
