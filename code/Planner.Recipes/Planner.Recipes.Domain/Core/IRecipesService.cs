using Planner.Recipes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Recipes.Domain.Core
{
    public interface IRecipesService
    {
        Task<int> GetRecipesTotalCountAsync(SearchParameter searchParameter, CancellationToken cancellationToken);

        Task<IEnumerable<Recipe>> GetRecipesAsync(SearchParameter searchParameter, CancellationToken cancellationToken);

        Task<Recipe> GetRecipeDetailsAsync(Guid recipeId, CancellationToken cancellationToken);

        Task AddRecipeToFavoritesAsync(Guid recipeId, Guid userId, CancellationToken cancellationToken);

        Task RemoveRecipeFromFavoritesAsync(Guid recipeId, Guid userId, CancellationToken cancellationToken);
    }
}
