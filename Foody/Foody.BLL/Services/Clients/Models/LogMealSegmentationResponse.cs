using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Services.Clients.Models
{
    public class LogMealSegmentationResponse
    {
        public int imageId { get; set; }

        public List<SegmentationResult> segmentation_results { get; set; }

    }

    public class SegmentationResult
    {
        public int food_item_position { get; set; }
        public List<int> polygon { get; set; }
    }
}
