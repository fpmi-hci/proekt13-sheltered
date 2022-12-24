using System;
using System.Collections.Generic;

namespace Planner.Recipes.Domain.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductPortion> ProductPortions { get; set; }
    }
}
