using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foody.IdentityAccessLayer.Configuration.EntityConfigurations
{
    public class IdentityUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserToken<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
        {
            builder.ToTable("identity_user_tokens");
            builder.Property(iut => iut.UserId).HasColumnName("user_id");
            builder.Property(iut => iut.LoginProvider).HasColumnName("login_provider");
            builder.Property(iut => iut.Name).HasColumnName("name");
            builder.Property(iut => iut.Value).HasColumnName("value");
        }
    }
}
