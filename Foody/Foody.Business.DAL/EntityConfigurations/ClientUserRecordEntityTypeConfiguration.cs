using Foody.Business.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.EntityConfigurations
{
    public class ClientUserRecordEntityTypeConfiguration : IEntityTypeConfiguration<ClientUserRecord>
    {
        public void Configure(EntityTypeBuilder<ClientUserRecord> builder)
        {
            builder.ToTable("client_users");

            // Primary Key
            builder.HasKey(cu => cu.Id);
            builder.Property(cu => cu.Id).HasColumnName("id");

            // User Relationship
            builder.Property(cu => cu.UserId).HasColumnName("user_id");
            builder.HasOne(cu => cu.User)
                   .WithMany() // Assuming no collection navigation on ApplicationUserRecord
                   .HasForeignKey(cu => cu.UserId);

            // Protected Personal Data
            builder.Property(cu => cu.FirstName).HasColumnName("first_name");
            builder.Property(cu => cu.LastName).HasColumnName("last_name");
            builder.Property(cu => cu.DateOfBirth).HasColumnName("date_of_birth");
            builder.Property(cu => cu.Gender).HasColumnName("gender");

            // ChatId
            builder.Property(cu => cu.ChatId).HasColumnName("chat_id");
        }
    }
}
