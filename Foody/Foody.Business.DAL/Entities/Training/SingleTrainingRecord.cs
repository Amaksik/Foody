using Foody.Domain.Entities.TrainerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities.Training
{
    public class SingleTrainingRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MuscleGroups> MuscleGroups { get; set; }
        public string? Description { get; set; }

        public ICollection<SingleExcerciseRecord> Excercises { get; set; }

        public string? Notes { get; set; }

        public int TrainerId { get; set; }
        public TrainerUserRecord Trainer { get; }
    }
}