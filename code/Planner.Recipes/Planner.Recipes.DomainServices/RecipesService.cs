using Planner.Recipes.Domain.Core;
using Planner.Recipes.Domain.Models;
using Planner.Recipes.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Recipes.DomainServices
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly IFavoritesRepository _favoritesRepository;

        public RecipesService(
            IRecipesRepository recipesRepository,
            IFavoritesRepository favoritesRepository)
        {
            _recipesRepository = recipesRepository;
            _favoritesRepository = favoritesRepository;
        }

        public Task AddRecipeToFavoritesAsync(
            Guid recipeId,
            Guid userId,
            CancellationToken cancellationToken)
        {
            var model = new Favorite()
            {
                UserId = userId,
                RecipeId = recipeId
            };

            return _favoritesRepository.CreateAsync(model, cancellationToken);
        }

        public async Task RemoveRecipeFromFavoritesAsync(
            Guid recipeId,
            Guid userId, 
            CancellationToken cancellationToken)
        {
            var model = new Favorite()
            {
                UserId = userId,
                RecipeId = recipeId
            };

            await _favoritesRepository.DeleteAsync(model, cancellationToken);
        }

        public Task<Recipe> GetRecipeDetailsAsync(
            Guid recipeId, 
            CancellationToken cancellationToken)
        {
            return _recipesRepository.GetAsync(recipeId, cancellationToken);
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(
            SearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            if (searchParameter is FavoritesSearchParameter favoritesSearch)
            {
                var favorites = await _favoritesRepository.GetAllAsync(
                    favoritesSearch, 
                    cancellationToken);

                return favorites.Select(_ => _.Recipe);
            }

            return await _recipesRepository.GetAllAsync(
                searchParameter as RecipesSearchParameter, 
                cancellationToken);
        }

        public Task<int> GetRecipesTotalCountAsync(
            SearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            if (searchParameter is FavoritesSearchParameter favoritesSearch)
            {
                return _favoritesRepository.CountAsync(
                    favoritesSearch, 
                    cancellationToken);
            }

            return _recipesRepository.CountAsync(
                searchParameter as RecipesSearchParameter, 
                cancellationToken);
        }
    }
}
