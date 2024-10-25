using Foody.Business.DAL.Entities;
using Foody.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL
{
    public class ClientUserRecordEntityTypeConfiguration : IEntityTypeConfiguration<ClientUserRecord>
    {
        public void Configure(EntityTypeBuilder<ClientUserRecord> builder)
        {
            builder.ToTable("clients");

            // Primary Key
            builder.HasKey(cu => cu.Id);
            builder.Property(cu => cu.Id).HasColumnName("id");

            // User Relationship
            builder.Property(cu => cu.UserId).HasColumnName("user_id");
            builder.HasOne(cu => cu.User)
                   .WithMany() // Assuming no collection navigation property on ApplicationUserRecord
                   .HasForeignKey(cu => cu.UserId);

            //// Trainer Relationship
            //builder.Property(cu => cu.TrainerId).HasColumnName("trainer_id");
            //builder.HasOne(cu => cu.Trainer)
            //       .WithMany() // Assuming no collection navigation property on TrainerUserRecord
            //       .HasForeignKey(cu => cu.TrainerId)
            //       .OnDelete(DeleteBehavior.SetNull);

            // Protected Personal Data
            builder.Property(cu => cu.FirstName)
                   .HasColumnName("first_name")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(cu => cu.LastName)
                   .HasColumnName("last_name")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(cu => cu.DateOfBirth)
                   .HasColumnName("date_of_birth")
                   .IsRequired();

            builder.Property(cu => cu.Gender)
                   .HasColumnName("gender")
                   .IsRequired();

            // ChatId
            builder.Property(cu => cu.ChatId)
                   .HasColumnName("chat_id")
                   .HasMaxLength(255);
        }
    }
}
