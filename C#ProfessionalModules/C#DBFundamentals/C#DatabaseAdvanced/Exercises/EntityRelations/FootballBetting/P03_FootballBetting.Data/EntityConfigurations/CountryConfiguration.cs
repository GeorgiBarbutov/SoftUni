using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(b => b.CountryId);

            builder.HasMany(b => b.Towns)
                   .WithOne(t => t.Country)
                   .HasForeignKey(t => t.CountryId);
        }
    }
}
