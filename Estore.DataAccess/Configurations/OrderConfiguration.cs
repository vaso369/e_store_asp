using Estore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(80).IsRequired();
            builder.Property(x => x.OrderStatus).HasDefaultValue(OrderStatus.OnHold);
            builder.Property(x => x.PaymentOption).HasDefaultValue(PaymentOption.Cash);
            builder.HasMany(o => o.OrderLines).WithOne(ol => ol.Order).HasForeignKey(ol => ol.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
