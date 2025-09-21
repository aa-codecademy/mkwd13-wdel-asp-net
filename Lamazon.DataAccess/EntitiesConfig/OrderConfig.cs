using Lamazon.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.EntitiesConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CountryCode).HasMaxLength(5);
            builder.Property(x=>x.IpAddress).HasMaxLength(50);
            builder.Property(x=>x.TotalAmount).IsRequired().HasPrecision(10, 2);

            builder.HasOne(x=>x.User)
                .WithMany(x=>x.Orders)
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Order_User");

            builder.HasOne(x => x.OrderStatus)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.OrderStatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Order_OrderStatus");
        }
    }
}
