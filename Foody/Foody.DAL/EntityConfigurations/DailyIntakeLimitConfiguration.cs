using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.DAL.Entities;

namespace Foody.DAL.Configurations
{
    public class DailyIntakeLimitConfiguration : IEntityTypeConfiguration<DailyIntakeLimitRecord>
    {
        public void Configure(EntityTypeBuilder<DailyIntakeLimitRecord> builder)
        {
            builder.ToTable("daily_limits");

            builder.HasKey(k => k.DailyIntakeLimitId);

            builder.Property(x => x.DailyIntakeLimitId)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DailyCaloriesIntake)
                .HasColumnName("calories");

            builder.Property(x => x.DailyCarbsIntake)
                .HasColumnName("carbs");

            builder.Property(x => x.DailyProteinIntake)
                .HasColumnName("protein");

            builder.Property(x => x.DailyFatIntake)
                .HasColumnName("fat");

            builder.Property(x => x.DailyWaterIntake)
                .HasColumnName("water");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithOne(e => e.DailyLimits)
                .HasForeignKey<DailyIntakeLimitRecord>(e => e.UserId)
                .IsRequired();

        }
    }
}
