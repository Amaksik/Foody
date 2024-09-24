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

        public string Phone { get; set; }

        public string ChatId { get; set; }

        public DailyIntakeLimit DailyLimits { get; set; }

        public Goal PersonalGoal { get; set; }

        public Measurements CurrentMeasurements { get; set; }

        public ICollection<FoodIntake> FoodIntakes { get; set; }

        public ICollection<WaterIntake> WaterIntakes { get; set; }
    }
}