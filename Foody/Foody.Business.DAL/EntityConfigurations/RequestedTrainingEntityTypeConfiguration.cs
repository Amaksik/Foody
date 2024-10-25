using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.Business.DAL.Entities;

namespace Foody.Business.DAL.EntityConfigurations
{
    public class RequestedTrainingEntityTypeConfiguration : IEntityTypeConfiguration<RequestedTrainingRecord>
    {
        public void Configure(EntityTypeBuilder<RequestedTrainingRecord> builder)
        {
            builder.ToTable("requested_trainings");

            // Primary Key
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            // ClientUserRecord Relationship
            builder.Property(rt => rt.CllientId)
                .HasColumnName("client_id")
                .IsRequired();
            builder.HasOne(rt => rt.ClientUserRecord)
                   .WithMany() // Assuming no collection navigation on ClientUserRecord
                   .HasForeignKey(rt => rt.CllientId);

            // Request Date
            builder.Property(rt => rt.RequestDate).HasColumnName("request_date");

            // Training Status
            builder.Property(rt => rt.TrainingStatus).HasColumnName("training_status");
                

        }
    }
}
