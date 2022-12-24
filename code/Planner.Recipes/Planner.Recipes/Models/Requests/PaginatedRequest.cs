namespace Planner.Recipes.WebApi.Models.Requests
{
    public class PaginatedRequest
    {
        public int Limit { get; set; } = 100;

        public int Offset { get; set; } = 0;
    }
}
