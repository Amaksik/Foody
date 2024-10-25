using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Business.DAL.Entities
{
    public class RequestedTrainingRecord
    {
        public int Id { get; set; }

        public int CllientId { get; set; }
        public ClientUserRecord ClientUserRecord { get; set; }

        public DateTime RequestDate { get; set; }

        public RequestedTrainingStatusType TrainingStatus { get; set; }
    }
}
