using Estore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Description).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            builder.HasMany(p => p.Prices).WithOne(pr => pr.Product).HasForeignKey(pr => pr.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Pictures).WithOne(pr => pr.Product).HasForeignKey(pr => pr.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.OrderLines).WithOne(ol => ol.Product).HasForeignKey(ol => ol.ProductId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
