using Foody.IdentityAccessLayer.Record;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer.Configuration
{
    public class ApplicationUserRecordEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserRecord>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRecord> builder)
        {
            builder.ToTable("identity_users");
            builder.Property(iu => iu.Id).HasColumnName("id");
            builder.Property(iu => iu.UserName).HasColumnName("user_name");

            builder.Property(iu => iu.NormalizedUserName).HasColumnName("normalized_user_name");

            builder.Property(iu => iu.Email).HasColumnName("email");
            builder.HasIndex(iu => iu.Email).IsUnique();

            builder.Property(iu => iu.NormalizedEmail).HasColumnName("normalized_email");
            builder.Property(iu => iu.EmailConfirmed).HasColumnName("email_confirmed");
            builder.Property(iu => iu.PasswordHash).HasColumnName("password_hash");
            builder.Property(iu => iu.SecurityStamp).HasColumnName("security_stamp");
            builder.Property(iu => iu.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            builder.Property(iu => iu.PhoneNumber).HasColumnName("phone_number");
            builder.Property(iu => iu.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            builder.Property(iu => iu.TwoFactorEnabled).HasColumnName("two_factor_enabled");
            builder.Property(iu => iu.LockoutEnd).HasColumnName("lockout_end");
            builder.Property(iu => iu.LockoutEnabled).HasColumnName("lockout_enabled");
            builder.Property(iu => iu.AccessFailedCount).HasColumnName("access_failed_count");
            builder.Property(iu => iu.LastLoginDate).HasColumnName("last_login_date");
            builder.Property(iu => iu.CreationDate).HasColumnName("creation_date").IsRequired();

            builder.Property(iu => iu.FullName).HasColumnName("full_name")
                .HasMaxLength(30);

            builder.HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
