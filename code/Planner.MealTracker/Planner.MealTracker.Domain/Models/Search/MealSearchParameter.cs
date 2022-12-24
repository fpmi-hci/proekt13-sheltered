using System;

namespace Planner.MealTracker.Domain.Models.Search
{
    public class MealSearchParameter
    {
        public Guid MealId { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public MealType? Type { get; set; }

        public bool IncludeProducts { get; set; }
    }
}
