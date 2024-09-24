using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Models.DTO
{
    public class NutrionixDTO
    {
        public List<NutrionixFood> foods { get; set; }
    }

    public class NutrionixFood
    {
        public string? food_name { get; set; }
        public object? brand_name { get; set; }
        public double? serving_weight_grams { get; set; }
        public double? nf_calories { get; set; }
        public double? nf_total_fat { get; set; }
        public double? nf_total_carbohydrate { get; set; }
        public double? nf_protein { get; set; }
        public object? upc { get; set; }

    }
}
