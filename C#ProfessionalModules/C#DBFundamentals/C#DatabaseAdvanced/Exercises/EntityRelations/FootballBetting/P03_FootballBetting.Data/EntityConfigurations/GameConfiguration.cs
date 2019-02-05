using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfigurations
{
    class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.GameId);

            builder.HasOne(g => g.HomeTeam)
                   .WithMany(t => t.HomeGames)
                   .HasForeignKey(t => t.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.AwayTeam)
                   .WithMany(t => t.AwayGames)
                   .HasForeignKey(t => t.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.PlayerStatistics)
                   .WithOne(ps => ps.Game)
                   .HasForeignKey(ps => ps.GameId);
        }
    }
}
