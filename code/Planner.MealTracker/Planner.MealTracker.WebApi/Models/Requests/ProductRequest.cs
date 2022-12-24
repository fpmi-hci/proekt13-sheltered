using System;

namespace Planner.MealTracker.WebApi.Models.Requests
{
    public class ProductRequest
    {
        public Guid Id { get; set; }

        public int Weight { get; set; }
    }
}
