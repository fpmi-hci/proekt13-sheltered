using System;

namespace Planner.MealTracker.Domain.Models
{
    public class DailyProgress : Nutrition
    {
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }
    }
}
