using Microsoft.EntityFrameworkCore;
using ProductShop.Data.Config;
using ProductShop.Models;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext(DbContextOptions options) 
            : base(options)
        {
        }

        public ProductShopContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.BoughtProducts)
                .WithOne(p => p.Buyer)
                .HasForeignKey(p => p.BuyerId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SoldProducts)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId);
        }
    }
}
