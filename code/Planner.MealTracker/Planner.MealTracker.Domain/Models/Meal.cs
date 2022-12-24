using System;
using System.Collections.Generic;

namespace Planner.MealTracker.Domain.Models
{
    public class Meal
    {
        public Guid MealId { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public MealType Type { get; set; }

        public IEnumerable<MealProduct> MealProducts { get; set; }
    }
}
