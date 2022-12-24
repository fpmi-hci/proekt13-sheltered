using System;

namespace Planner.Recipes.Domain.Models
{
    public class Step
    {
        public Guid StepId { get; set; }

        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }
    }
}
