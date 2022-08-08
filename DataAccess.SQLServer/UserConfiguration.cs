using DataAccess.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLServer
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Id).IsUnique();

            builder.HasOne(u => u.Company)
                   .WithMany(c => c.Users)
                   .HasForeignKey(u => u.CompanyId);

            builder.HasOne(u => u.Company)
                   .WithMany(c => c.Users)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
