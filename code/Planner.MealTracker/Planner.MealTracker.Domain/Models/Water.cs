using System;

namespace Planner.MealTracker.Domain.Models
{
    public class Water
    {
        public Guid WaterId { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public int Cups { get; set; }
    }
}
