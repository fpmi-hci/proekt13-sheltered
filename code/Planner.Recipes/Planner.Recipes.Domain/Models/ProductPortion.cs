using System;

namespace Planner.Recipes.Domain.Models
{
    public class ProductPortion
    {
        public Guid ProductPortionId { get; set; }

        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public string Portion { get; set; }
    }
}
