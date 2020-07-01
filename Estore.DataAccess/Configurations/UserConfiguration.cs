using Estore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(60).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Pass).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PID).IsRequired();
            builder.HasIndex(x => x.PID).IsUnique();
            builder.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.UserUseCases).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);

        }

    }
}
