using System;
using System.Collections.Generic;

namespace Planner.MealTracker.Domain.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }

        public double Carbs { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public int Portion { get; set; }

        public IEnumerable<MealProduct> MealProducts { get; set; }
    }
}
