

namespace P03_SalesDatabase.Data
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CreditCardNumber)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(e => e.Email)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(80);
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(p => p.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(50);

                entity.Property(p => p.Price)
                    .IsRequired(true);

                entity.Property(p => p.Quantity)
                    .IsRequired(true);

                entity.Property(p => p.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValue("No description");
            });

            builder.Entity<Store>(entity =>
            {
                entity.HasKey(s => s.StoreId);

                entity.Property(s => s.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(80);
            });

            builder.Entity<Sale>(entity =>
            {
                entity.HasKey(p => p.SaleId);

                entity.Property(s => s.Date)
                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(s => s.Product)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(s => s.ProductId)
                    .HasConstraintName("FK_Product_Sales");

                entity.HasOne(a => a.Customer)
                    .WithMany(a => a.Sales)
                    .HasForeignKey(a => a.CustomerId)
                    .HasConstraintName("FK_Customer_Sales");

                entity.HasOne(a => a.Store)
                    .WithMany(a => a.Sales)
                    .HasForeignKey(a => a.StoreId)
                    .HasConstraintName("FK_Store_Sales");

            });

        }

      
    }
}
