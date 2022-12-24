using System;

namespace Planner.MealTracker.Domain.Models
{
    public class Goal : Nutrition
    {
        public Guid GoalId { get; set; }

        public Guid UserId { get; set; }
    }
}
