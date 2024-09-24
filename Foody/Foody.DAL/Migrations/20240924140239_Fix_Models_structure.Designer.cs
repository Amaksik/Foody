﻿// <auto-generated />
using System;
using Foody.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Foody.DAL.Migrations
{
    [DbContext(typeof(FoodyDbContext))]
    [Migration("20240924140239_Fix_Models_structure")]
    partial class Fix_Models_structure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Foody.DAL.Entities.DailyIntakeLimitRecord", b =>
                {
                    b.Property<int>("DailyIntakeLimitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DailyIntakeLimitId"));

                    b.Property<double?>("DailyCaloriesIntake")
                        .HasColumnType("double precision")
                        .HasColumnName("calories");

                    b.Property<double?>("DailyCarbsIntake")
                        .HasColumnType("double precision")
                        .HasColumnName("carbs");

                    b.Property<double?>("DailyFatIntake")
                        .HasColumnType("double precision")
                        .HasColumnName("fat");

                    b.Property<double?>("DailyProteinIntake")
                        .HasColumnType("double precision")
                        .HasColumnName("protein");

                    b.Property<double?>("DailyWaterIntake")
                        .HasColumnType("double precision")
                        .HasColumnName("water");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("DailyIntakeLimitId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("daily_limits", (string)null);
                });

            modelBuilder.Entity("Foody.DAL.Entities.FoodIntakeRecord", b =>
                {
                    b.Property<int>("FoodIntakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FoodIntakeId"));

                    b.Property<double>("Calories")
                        .HasColumnType("double precision")
                        .HasColumnName("calories");

                    b.Property<double?>("Carbs")
                        .HasColumnType("double precision")
                        .HasColumnName("carbs");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_time");

                    b.Property<double?>("Fat")
                        .HasColumnType("double precision")
                        .HasColumnName("fat");

                    b.Property<double?>("Protein")
                        .HasColumnType("double precision")
                        .HasColumnName("protein");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("FoodIntakeId");

                    b.HasIndex("UserId");

                    b.ToTable("food_intakes", (string)null);
                });

            modelBuilder.Entity("Foody.DAL.Entities.GoalRecord", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GoalId"));

                    b.Property<double?>("CurrentWeightValue")
                        .HasColumnType("double precision")
                        .HasColumnName("current_weight_value");

                    b.Property<double?>("GoalWeightValue")
                        .HasColumnType("double precision")
                        .HasColumnName("goal_weight_value");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("GoalId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("goals", (string)null);
                });

            modelBuilder.Entity("Foody.DAL.Entities.MeasurementsRecord", b =>
                {
                    b.Property<int>("MeasurementsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MeasurementsId"));

                    b.Property<double?>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("MeasurementsId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("measurements", (string)null);
                });

            modelBuilder.Entity("Foody.DAL.Entities.UserRecord", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("ChatId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("chat_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("UserId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Foody.DAL.Entities.WaterIntakeRecord", b =>
                {
                    b.Property<int>("WaterIntakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WaterIntakeId"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_time");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("WaterIntakeId");

                    b.HasIndex("UserId");

                    b.ToTable("water_intakes", (string)null);
                });

            modelBuilder.Entity("Foody.DAL.Entities.DailyIntakeLimitRecord", b =>
                {
                    b.HasOne("Foody.DAL.Entities.UserRecord", "User")
                        .WithOne("DailyLimits")
                        .HasForeignKey("Foody.DAL.Entities.DailyIntakeLimitRecord", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foody.DAL.Entities.FoodIntakeRecord", b =>
                {
                    b.HasOne("Foody.DAL.Entities.UserRecord", "User")
                        .WithMany("FoodIntakes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foody.DAL.Entities.GoalRecord", b =>
                {
                    b.HasOne("Foody.DAL.Entities.UserRecord", "User")
                        .WithOne("PersonalGoal")
                        .HasForeignKey("Foody.DAL.Entities.GoalRecord", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foody.DAL.Entities.MeasurementsRecord", b =>
                {
                    b.HasOne("Foody.DAL.Entities.UserRecord", "User")
                        .WithOne("CurrentMeasurements")
                        .HasForeignKey("Foody.DAL.Entities.MeasurementsRecord", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foody.DAL.Entities.WaterIntakeRecord", b =>
                {
                    b.HasOne("Foody.DAL.Entities.UserRecord", "User")
                        .WithMany("WaterIntakes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Foody.DAL.Entities.UserRecord", b =>
                {
                    b.Navigation("CurrentMeasurements")
                        .IsRequired();

                    b.Navigation("DailyLimits")
                        .IsRequired();

                    b.Navigation("FoodIntakes");

                    b.Navigation("PersonalGoal")
                        .IsRequired();

                    b.Navigation("WaterIntakes");
                });
#pragma warning restore 612, 618
        }
    }
}
