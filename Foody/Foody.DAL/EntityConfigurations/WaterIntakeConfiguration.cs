using Foody.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Configurations
{
    public class WaterIntakeConfiguration : IEntityTypeConfiguration<WaterIntakeRecord>
    {
        public void Configure(EntityTypeBuilder<WaterIntakeRecord> builder)
        {
            builder.ToTable("water_intakes");

            builder.HasKey(k => k.WaterIntakeId);

            builder.Property(x => x.WaterIntakeId)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Amount)
                .HasColumnName("amount")
                .IsRequired();

            builder.Property(x => x.DateTime)
                .HasColumnName("date_time")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(u => u.WaterIntakes)
                .HasForeignKey(k => k.UserId);

        }
    }
}
