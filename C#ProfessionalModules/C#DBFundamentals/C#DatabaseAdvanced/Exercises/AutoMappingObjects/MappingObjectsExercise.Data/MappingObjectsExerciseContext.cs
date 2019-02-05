using MappingObjectsExercise.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MappingObjectsExercise.Data
{
    public class MappingObjectsExerciseContext : DbContext
    {
        public MappingObjectsExerciseContext(DbContextOptions<MappingObjectsExerciseContext> options)
            : base(options)
        {
        }

        public MappingObjectsExerciseContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ManagedEmployees)
                .WithOne(me => me.Manager)
                .HasForeignKey(e => e.ManagerId);
        }
    }
}
