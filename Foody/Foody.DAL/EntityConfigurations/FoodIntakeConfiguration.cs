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
    public class FoodIntakeConfiguration : IEntityTypeConfiguration<FoodIntakeRecord>
    {
        public void Configure(EntityTypeBuilder<FoodIntakeRecord> builder)
        {
            builder.ToTable("food_intakes");

            builder.HasKey(k => k.FoodIntakeId);

            builder.Property(x => x.FoodIntakeId)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.Calories)
                .HasColumnName("calories")
                .IsRequired();

            builder.Property(x => x.Carbs)
                .HasColumnName("carbs");

            builder.Property(x => x.Protein)
                .HasColumnName("protein");

            builder.Property(x => x.Fat)
                .HasColumnName("fat");

            builder.Property(x => x.DateTime)
                .HasColumnName("date_time")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(u => u.FoodIntakes)
                .HasForeignKey(k => k.UserId);

        }
    }
}
