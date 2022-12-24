using Microsoft.EntityFrameworkCore;
using Planner.Recipes.Domain.Models;
using Planner.Recipes.Infrastructure.Core;
using Planner.Recipes.Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Recipes.Infrastructure
{
    public class FavoritesRepository : IFavoritesRepository
    {
        private readonly RecipesDbContext _context;

        public FavoritesRepository(RecipesDbContext context)
        {
            _context = context;
        }

        public Task<int> CountAsync(
            FavoritesSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            var query = FilterFavorites(searchParameter);
            return query.CountAsync(cancellationToken);
        }

        public async Task CreateAsync(Favorite entity, CancellationToken cancellationToken)
        {
            await _context.Favorites.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Favorite entity, CancellationToken cancellationToken)
        {
            var model = await _context.Favorites
                .FirstOrDefaultAsync(_ => _.RecipeId.Equals(entity.RecipeId) && 
                    _.UserId.Equals(entity.UserId));
            
            _context.Favorites.Remove(model);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Favorite>> GetAllAsync(
            FavoritesSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            var query = FilterFavorites(searchParameter);

            return query
                .Skip(searchParameter.Offset)
                .Take(searchParameter.Limit);
        }

        public Task<Favorite> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Favorite entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Favorite> FilterFavorites(FavoritesSearchParameter searchParameter)
        {
            var query = _context.Favorites
                .AsNoTracking()
                .Where(_ => _.UserId.Equals(searchParameter.UserId));

            if (searchParameter.Filter != null)
            {
                query = query
                    .Include(_ => _.Recipe)
                    .Where(_ => _.Recipe.Name.Contains(searchParameter.Filter));
            }
            else
            {
                query = query
                    .Include(_ => _.Recipe);
            }

            query = query
                .OrderBy(_ => _.Recipe.Name);

            return query;
        }
    }
}
