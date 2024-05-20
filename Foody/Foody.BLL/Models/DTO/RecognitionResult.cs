using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Models.DTO
{
    public class RecognitionResult
    {
        public RecognitionResult(string productName, double calories, double carbs, double fat, double protein)
        {
            ProductName = productName;
            Calories = calories;
            Carbs = carbs;
            Fat = fat;
            Protein = protein;
        }

        public string ProductName { get; set; }

        public double Calories { get; set; }

        public double Carbs { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }
    }
}
