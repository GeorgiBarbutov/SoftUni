using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.EntityConfiguration;
using System;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext( DbContextOptions options) 
        {
        }

        public SalesContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if(!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());
        }
    }
}
