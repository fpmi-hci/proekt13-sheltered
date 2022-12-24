using Planner.MealTracker.Domain.Models;
using System;
using System.Collections.Generic;

namespace Planner.MealTracker.WebApi.Models.Responses
{
    public class MealResponse
    {
        public Guid Id { get; set; }

        public MealType Type { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<MealProductResponse> Products { get; set; }
    }
}
