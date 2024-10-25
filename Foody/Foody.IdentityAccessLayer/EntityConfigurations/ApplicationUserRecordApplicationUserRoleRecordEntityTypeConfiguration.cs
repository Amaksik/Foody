using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.IdentityAccessLayer.Records;

namespace Foody.IdentityAccessLayer.EntityConfigurations
{
    public class ApplicationUserRecordApplicationUserRoleRecordEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserRecordApplicationUserRoleRecord>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRecordApplicationUserRoleRecord> builder)
        {
            builder.ToTable("identity_user_roles");
            builder.Property(ur => ur.UserId).HasColumnName("user_id");
            builder.Property(ur => ur.RoleId).HasColumnName("role_id");

            builder.HasOne(ur => ur.Role)
                .WithMany().HasForeignKey(ur => ur.RoleId);
        }
    }
}
