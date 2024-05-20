using Foody.DAL.Configurations;
using Foody.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL
{
    public class FoodyDbContext : DbContext
    {

        public FoodyDbContext(DbContextOptions<FoodyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new GoalConfiguration());
            builder.ApplyConfiguration(new FoodIntakeConfiguration());
            builder.ApplyConfiguration(new DailyIntakeLimitConfiguration());
            builder.ApplyConfiguration(new MeasurementsConfiguration());
            builder.ApplyConfiguration(new WaterIntakeConfiguration());
        }

        public DbSet<UserRecord> Users { get; set; }
        public DbSet<FoodIntakeRecord> FoodIntakes { get; set; }
        public DbSet<WaterIntakeRecord> WaterIntakes { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Configure the PostgreSQL connection string
        //    optionsBuilder.UseNpgsql("Your_PostgreSQL_Connection_String");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure the primary key for the User table
        //    modelBuilder.Entity<User>()
        //        .HasKey(u => u.UserId);

        //    // Configure the primary key for the FoodIntake table
        //    modelBuilder.Entity<FoodIntakeConfiguration>()
        //        .HasKey(fi => fi.FoodIntakeId);

        //    // Configure the primary key for the WaterIntake table
        //    modelBuilder.Entity<WaterIntake>()
        //        .HasKey(wi => wi.WaterIntakeId);

        //    // Configure the primary key for the Goal table
        //    modelBuilder.Entity<Goal>()
        //        .HasKey(g => g.GoalId);

        //    // Configure relationships between entities

        //    // User to FoodIntake (one-to-many)
        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.FoodIntakes)
        //        .WithOne(fi => fi.User)
        //        .HasForeignKey(fi => fi.UserId);

        //    // User to WaterIntake (one-to-many)
        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.WaterIntakes)
        //        .WithOne(wi => wi.User)
        //        .HasForeignKey(wi => wi.UserId);

        //    // User to Goal (one-to-one)
        //    modelBuilder.Entity<User>()
        //        .HasOne(u => u.PersonalGoal)
        //        .WithOne(g => g.User)
        //        .HasForeignKey<Goal>(g => g.UserId);
        //}


    }
}
