using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfigurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.PlayerId);

            builder.HasMany(p => p.PlayerStatistics)
                   .WithOne(ps => ps.Player)
                   .HasForeignKey(ps => ps.PlayerId);

            builder.HasOne(p => p.Team)
                   .WithMany(t => t.Players)
                   .HasForeignKey(p => p.TeamId);

            builder.HasOne(p => p.Position)
                   .WithMany(p => p.Players)
                   .HasForeignKey(p => p.PositionId);
        }
    }
}
