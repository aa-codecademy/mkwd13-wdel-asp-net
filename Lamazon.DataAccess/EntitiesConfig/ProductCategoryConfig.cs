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
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

            builder.HasOne(x=>x.ProductCategoryStatus)
                .WithMany(x=>x.ProductCategories)
                .HasForeignKey(x=>x.ProductCategoryStatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_ProductCategory_ProductCategoryStatus");
        }
    }
}
