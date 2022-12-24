using System;

namespace Planner.MealTracker.Domain.Models
{
    public class MealProduct
    {
        public Guid MealProductId { get; set; }

        public Guid MealId { get; set; }

        public Meal Meal { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Weight { get; set; }
    }
}
