namespace Planner.Recipes.Domain.Models
{
    public class SearchParameter
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public string Filter { get; set; }
    }
}
