using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// User model representing the users table
namespace Foody.BLL.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string ChatId { get; set; }

        public DailyIntakeLimit DailyLimits { get; set; }

        // Navigation property for goal records
        public Goal PersonalGoal { get; set; }

        // Navigation property for measurements records
        public MeasurementsRecord CurrentMeasurements { get; set; }

        // Navigation property for food intake records
        public ICollection<FoodIntake> FoodIntakes { get; set; }

        // Navigation property for water intake records
        public ICollection<WaterIntake> WaterIntakes { get; set; }
    }
}