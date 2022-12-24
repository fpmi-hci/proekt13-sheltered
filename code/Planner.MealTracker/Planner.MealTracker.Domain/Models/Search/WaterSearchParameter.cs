using System;

namespace Planner.MealTracker.Domain.Models.Search
{
    public class WaterSearchParameter
    {
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }
    }
}
