﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.HasMany(p => p.Sales)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId);
        }
    }
}
