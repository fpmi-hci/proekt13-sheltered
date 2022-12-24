using System;

namespace Planner.MealTracker.Domain.Models.Search
{
    public class DailyProgressSearchParameter
    {
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }
    }
}
