﻿namespace Foody.Web.Models.Requests
{
    public class CreateFoodIntakeReq
    {
        public double Calories { get; set; }

        public double? Carbs { get; set; }

        public double? Fat { get; set; }

        public double? Protein { get; set; }
    }
}
