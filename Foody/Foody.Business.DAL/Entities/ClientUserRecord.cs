using Foody.Business.DAL.Entities.ClientMeasurements;
using Foody.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities
{
    public class ClientUserRecord
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public ApplicationUserRecord User { get; set; }

        [ProtectedPersonalData]
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        public string LastName { get; set; }

        [ProtectedPersonalData]
        public DateTime DateOfBirth { get; set; }

        [ProtectedPersonalData]
        public Gender Gender { get; set; }

        //public int? TrainerId { get; set; }

        //public TrainerUserRecord Trainer { get; set; }

        public string ChatId { get; set; }

        //public DailyIntakeLimitRecord DailyLimits { get; set; }

        //// Navigation property for goal records
        //public GoalRecord PersonalGoal { get; set; }

        //// Navigation property for measurements records
        //public MeasurementsRecord CurrentMeasurements { get; set; }

        //// Navigation property for food intake records
        //public ICollection<FoodIntakeRecord> FoodIntakes { get; set; }

        //// Navigation property for water intake records
        //public ICollection<WaterIntakeRecord> WaterIntakes { get; set; }

        public ICollection<RequestedTrainingRecord> Trainings { get; set; }

    }
}
