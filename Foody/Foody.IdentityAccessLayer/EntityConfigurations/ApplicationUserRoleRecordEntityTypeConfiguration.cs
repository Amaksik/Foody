using Foody.Domain.Entities;
using Foody.IdentityAccessLayer.Records;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer.EntityConfigurations
{
    public class ApplicationUserRoleRecordEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserRoleRecord>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRoleRecord> builder)
        {
            builder.ToTable("roles");
            builder.Property(ir => ir.Id).HasColumnName("id");
            builder.Property(ir => ir.Name).HasColumnName("name");
            builder.Property(ir => ir.NormalizedName).HasColumnName("normalized_name");
            builder.Property(ir => ir.ConcurrencyStamp).HasColumnName("concurrency_stamp");


            builder.HasData(
                new ApplicationUserRoleRecord
                { 
                    Id = 1,
                    Name = nameof(Roles.Client),
                    NormalizedName = nameof(Roles.Client).ToUpper()
                },
                new ApplicationUserRoleRecord
                {
                    Id = 2,
                    Name = nameof(Roles.Trainer),
                    NormalizedName = nameof(Roles.Trainer).ToUpper()
                },
                new ApplicationUserRoleRecord
                {
                    Id = 3,
                    Name = nameof(Roles.Organization),
                    NormalizedName = nameof(Roles.Organization).ToUpper()
                },
                new ApplicationUserRoleRecord
                {
                    Id = 4,
                    Name = nameof(Roles.SuperAdmin),
                    NormalizedName = nameof(Roles.SuperAdmin).ToUpper()
                }
                );
            ;

        }
    }
}
