using Lamazon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.EntitiesConfig
{
    public class OrderLineItemConfig : IEntityTypeConfiguration<OrderLineItem>
    {
        public void Configure(EntityTypeBuilder<OrderLineItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProductPrice).IsRequired().HasPrecision(10, 2);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x=>x.TotalPrice).IsRequired().HasPrecision(10, 2);

            builder.HasOne(x=>x.Order)
                .WithMany(x=>x.OrderLineItems)
                .HasForeignKey(x=>x.OrderId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_OrderLineItem_Order");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderLineItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_OrderLineItem_Product");
        }
    }
}
