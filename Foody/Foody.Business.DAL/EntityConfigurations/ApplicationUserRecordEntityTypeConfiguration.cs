using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.Business.DAL.Entities;

namespace Foody.Business.DAL.EntityConfigurations
{
    public class ApplicationUserRecordEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserRecord>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRecord> builder)
        {
            builder.ToTable("identity_users");

            builder.Property(iu => iu.Id)
                .HasColumnName("id");

            builder.Property(iu => iu.FullName)
                .HasColumnName("full_name");

            builder.HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
