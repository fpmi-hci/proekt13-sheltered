using System;

namespace Planner.Recipes.Domain.Models
{
    public class FavoritesSearchParameter : SearchParameter
    {
        public Guid UserId { get; set; }
    }
}
