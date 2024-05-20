using Foody.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

// User model representing the users table
namespace Foody.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserRecord>
    {
        public void Configure(EntityTypeBuilder<UserRecord> builder)
        {
            builder.ToTable("users");

            builder.HasKey(k => k.UserId);

            builder.Property(x => x.UserId)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnName("surname");

            builder.Property(x => x.Email)
                .HasColumnName("email");

            builder.Property(x => x.Phone)
                .HasColumnName("phone");

            builder.Property(x => x.ChatId)
                .HasColumnName("chat_id")
                .IsRequired();
        }
    }
}