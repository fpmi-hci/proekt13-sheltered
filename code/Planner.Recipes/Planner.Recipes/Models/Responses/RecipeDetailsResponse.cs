using System.Collections.Generic;

namespace Planner.Recipes.WebApi.Models.Responses
{
    public class RecipeDetailsResponse : RecipeResponse
    {
        public string Time { get; set; }

        public IEnumerable<ProductResponse> Products { get; set; }

        public IEnumerable<string> Steps { get; set; }
    }
}
