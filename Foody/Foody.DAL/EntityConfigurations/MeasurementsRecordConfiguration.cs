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
    public class MeasurementsConfiguration : IEntityTypeConfiguration<MeasurementsRecord>
    {
        public void Configure(EntityTypeBuilder<MeasurementsRecord> builder)
        {
            builder.ToTable("measurements");

            builder.HasKey(k => k.MeasurementsId);

            builder.Property(x => x.MeasurementsId)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Height)
                .HasColumnName("height");

            builder.Property(x => x.Weight)
                .HasColumnName("weight");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithOne(e => e.CurrentMeasurements)
                .HasForeignKey<MeasurementsRecord>(e => e.UserId)
                .IsRequired();

        }
    }
}
