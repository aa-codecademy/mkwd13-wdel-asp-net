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
    public class InvoiceLineItemConfig : IEntityTypeConfiguration<InvoiceLineItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceLineItem> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(255);
            builder.Property(x=>x.ProductPrice).IsRequired().HasPrecision(10, 2);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x=>x.TotalPrice).IsRequired().HasPrecision(10, 2);

            builder.HasOne(x=>x.OrderLineItem)
                .WithMany(x=>x.InvoiceLineItems)
                .HasForeignKey(x=>x.OrderLineItemId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_InvoiceLineItem_OrderLineItem");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.InvoiceLineItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_InvoiceLineItem_Product");

            builder.HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceLineItems)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_InvoiceLineItem_Invoice");


        }
    }
}
