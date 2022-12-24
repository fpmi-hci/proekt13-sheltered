using System.Collections.Generic;

namespace Planner.Recipes.WebApi.Models.Responses
{
    public class RecipesResponse
    {
        public int Count { get; set; }

        public IEnumerable<RecipeResponse> Recipes { get; set; }
    }
}
