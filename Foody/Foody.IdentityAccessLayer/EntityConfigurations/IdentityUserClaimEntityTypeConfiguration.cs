using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.IdentityAccessLayer.Configuration.EntityConfigurations
{
    public class IdentityUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
        {
            builder.ToTable("identity_user_claims");
            builder.Property(iuc => iuc.Id).HasColumnName("id");
            builder.Property(iuc => iuc.UserId).HasColumnName("user_id");
            builder.Property(iuc => iuc.ClaimType).HasColumnName("claim_type");
            builder.Property(iuc => iuc.ClaimValue).HasColumnName("claim_value");
        }
    }
}
