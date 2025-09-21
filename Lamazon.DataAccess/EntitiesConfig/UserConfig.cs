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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x=>x.PasswordHash).IsRequired().HasMaxLength(500);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(128);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasOne(x=>x.Role)
                .WithMany(x=>x.Users)
                .HasForeignKey(x=>x.RoleKey)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_User_Role");
        }
    }
}
