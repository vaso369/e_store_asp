using Estore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(p => p.Products).WithOne(c => c.Category).HasForeignKey(pr => pr.CategoryId).OnDelete(DeleteBehavior.Restrict);



        }
    }
}
