using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities.Training
{
    public class SingleExcerciseRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }
        public string? EplanationUrl { get; set; }

        public IEnumerable<TrainingSetRecord> TrainingSets { get; set; }

        public string Notes { get; set; }

        public int ExcerciseRecordId { get; set; }
        public SingleExcerciseRecord ExcerciseRecord { get; set; }

    }
}