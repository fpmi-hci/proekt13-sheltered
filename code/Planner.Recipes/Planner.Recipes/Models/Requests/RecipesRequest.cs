namespace Planner.Recipes.WebApi.Models.Requests
{
    public class RecipesRequest : PaginatedRequest
    {
        public string Filter { get; set; }

        public bool Favorites { get; set; }
    }
}
