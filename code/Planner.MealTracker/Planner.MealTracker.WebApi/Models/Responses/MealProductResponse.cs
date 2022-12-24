using System;

namespace Planner.MealTracker.WebApi.Models.Responses
{
    public class MealProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }

        public double Carbs { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public int Weight { get; set; }
    }
}
