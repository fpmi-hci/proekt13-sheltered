using System;

namespace Planner.Recipes.Domain.Models
{
    public class Favorite
    {
        public Guid FavoriteId { get; set; }

        public Guid UserId { get; set; }

        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
