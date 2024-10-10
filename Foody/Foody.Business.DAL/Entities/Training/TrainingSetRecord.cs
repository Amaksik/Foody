using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities.Training
{
    public class TrainingSetRecord
    {
        public int Repetiotions { get; set; }
        public double RestTime { get; set; }

        public int EscerciseId { get; set; }
        public SingleExcerciseRecord ExcerciseRecord { get; }

    }
}