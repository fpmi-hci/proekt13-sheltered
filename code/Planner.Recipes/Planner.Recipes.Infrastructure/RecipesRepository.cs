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
    public class RecipesRepository : IRecipesRepository
    {
        private readonly RecipesDbContext _context;

        public RecipesRepository(RecipesDbContext context)
        {
            _context = context;
        }

        public Task<int> CountAsync(RecipesSearchParameter searchParameter, CancellationToken cancellationToken)
        {
            var query = FilterRecipes(searchParameter);

            return query.CountAsync(cancellationToken);
        }

        public Task CreateAsync(Recipe entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Recipe entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync(
            RecipesSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            var query = FilterRecipes(searchParameter);

            return query
                .Skip(searchParameter.Offset)
                .Take(searchParameter.Limit);
        }

        public Task<Recipe> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return _context.Recipes
                .AsNoTracking()
                .Include(_ => _.Steps)
                .Include(_ => _.ProductPortions)
                .ThenInclude(_ => _.Product)
                .SingleOrDefaultAsync(_ => _.RecipeId.Equals(id), cancellationToken);
        }

        public Task UpdateAsync(Recipe entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Recipe> FilterRecipes(RecipesSearchParameter searchParameter)
        {
            var query = _context.Recipes.AsNoTracking();

            if (!string.IsNullOrEmpty(searchParameter.Filter))
            {
                query = query
                    .Where(_ => _.Name
                        .Contains(searchParameter.Filter));
            }

            return query.OrderBy(_ => _.Name);
        }
    }
}
