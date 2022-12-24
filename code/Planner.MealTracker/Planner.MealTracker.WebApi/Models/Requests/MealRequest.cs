using Planner.MealTracker.Domain.Models;
using System;

namespace Planner.MealTracker.WebApi.Models.Requests
{
    public class MealRequest
    {
        public MealType Type { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
