using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// User model representing the users table
namespace Foody.DAL.Entities
{
    public class UserRecord
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        [Required]
        public string ChatId { get; set; }

        public DailyIntakeLimitRecord DailyLimits { get; set; }

        // Navigation property for goal records
        public GoalRecord PersonalGoal { get; set; }

        // Navigation property for measurements records
        public MeasurementsRecord CurrentMeasurements { get; set; }

        // Navigation property for food intake records
        public ICollection<FoodIntakeRecord> FoodIntakes { get; set; }

        // Navigation property for water intake records
        public ICollection<WaterIntakeRecord> WaterIntakes { get; set; }
    }
}