using System;
using System.Collections.Generic;

namespace Planner.Recipes.Domain.Models
{
    public class Recipe
    {
        public Guid RecipeId { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int Calories { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public int Proteins { get; set; }

        public string Time { get; set; }

        public IEnumerable<ProductPortion> ProductPortions { get; set; }

        public IEnumerable<Step> Steps { get; set; }

        public IEnumerable<Favorite> Favorites { get; set; }
    }
}
