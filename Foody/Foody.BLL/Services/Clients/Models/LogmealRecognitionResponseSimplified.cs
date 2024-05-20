using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foody.BLL.Services.Clients.Models
{
    public class LogmealRecognitionResponseSimplified
    {
        public List<string> foodName { get; set; }
        public bool hasNutritionalInfo { get; set; }
        public int imageId { get; set; }
        public NutritionalInfoSimplified nutritional_info { get; set; }
    }
    public class NutritionalInfoSimplified
    {
        public double calories { get; set; }
        public TotalNutrientsSimplified totalNutrients { get; set; }
    }
    public class TotalNutrientsSimplified
    {
        public CHOCDF CHOCDF { get; set; }
        public PROCNT PROCNT { get; set; }
        public FAT FAT { get; set; }
        public SUGAR SUGAR { get; set; }

        [JsonPropertyName("SUGAR.added")]
        public SUGARAdded SUGARadded { get; set; }
    }
}
