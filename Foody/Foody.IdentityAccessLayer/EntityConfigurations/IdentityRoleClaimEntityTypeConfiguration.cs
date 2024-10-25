using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.IdentityAccessLayer.Configuration.EntityConfigurations
{
    public class IdentityRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
        {
            builder.ToTable("role_permissions");
            builder.Property(irc => irc.Id).HasColumnName("id");
            builder.Property(irc => irc.RoleId).HasColumnName("role_id");
            builder.Property(irc => irc.ClaimType).HasColumnName("permission_type");
            builder.Property(irc => irc.ClaimValue).HasColumnName("permission_value");
        }
    }
}
