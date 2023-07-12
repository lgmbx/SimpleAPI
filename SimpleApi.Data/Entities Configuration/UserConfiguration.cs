using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Data.Entities_Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Username)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(t => t.Password)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.Role)
                .IsRequired();
        }
    }
}
