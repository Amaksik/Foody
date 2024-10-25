using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.IdentityAccessLayer.Configuration.EntityConfigurations
{
    public class IdentityUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserLogin<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder)
        {
            builder.ToTable("identity_user_logins");
            builder.Property(iul => iul.UserId).HasColumnName("user_id");
            builder.Property(iul => iul.LoginProvider).HasColumnName("login_provider");
            builder.Property(iul => iul.ProviderKey).HasColumnName("provider_key");
            builder.Property(iul => iul.ProviderDisplayName).HasColumnName("provider_display_name");
        }
    }
}
