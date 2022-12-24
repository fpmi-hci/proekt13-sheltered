using Planner.MealTracker.Domain.Models;
using System;
using System.Collections.Generic;

namespace Planner.MealTracker.WebApi.Models.Requests
{
    public class MealProductsRemoveRequest
    {
        public DateTime Date { get; set; }

        public MealType Type { get; set; }

        public IEnumerable<Guid> Products { get; set; }
    }
}
