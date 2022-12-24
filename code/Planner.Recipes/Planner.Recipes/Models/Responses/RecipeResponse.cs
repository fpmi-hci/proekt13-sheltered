using System;

namespace Planner.Recipes.WebApi.Models.Responses
{
    public class RecipeResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int Calories { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public int Proteins { get; set; }
    }
}
