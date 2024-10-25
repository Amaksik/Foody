using Foody.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Foody.DAL.Configurations
{
    public class GoalConfiguration : IEntityTypeConfiguration<GoalRecord>
    {
        public void Configure(EntityTypeBuilder<GoalRecord> builder)
        {
            builder.ToTable("goals");

            builder.HasKey(k => k.GoalId);

            builder.Property(x => x.GoalId)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.GoalWeightValue)
                .HasColumnName("goal_weight_value");

            builder.Property(x => x.CurrentWeightValue)
                .HasColumnName("current_weight_value");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithOne(e => e.PersonalGoal)
                .HasForeignKey<GoalRecord>(e => e.UserId)
                .IsRequired();

        }
    }
}
