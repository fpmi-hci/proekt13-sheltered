using Microsoft.EntityFrameworkCore;
using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.Infrastructure
{
    public class MealRepository : IMealRepository
    {
        private readonly MealTrackerDbContext _context;

        public MealRepository(MealTrackerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Meal entity, CancellationToken cancellationToken)
        {
            await _context.Meals.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(Meal entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Meal>> GetAllAsync(
            MealSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return FilterMeals(searchParameter);
        }

        public Task<Meal> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Meal entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AttachAsync(Meal entity, CancellationToken cancellationToken)
        {
            _context.Meals.Attach(entity);
        }

        private IQueryable<Meal> FilterMeals(MealSearchParameter searchParameter)
        {
            var query = _context.Meals
                .AsNoTracking()
                .Where(_ => _.UserId.Equals(searchParameter.UserId) && _.Date.Equals(searchParameter.Date));

            if (searchParameter.Type.HasValue)
            {
                query = query
                    .Where(_ => _.Type.Equals(searchParameter.Type.Value));
            }

            if (searchParameter.IncludeProducts)
            {
                query = query
                    .Include(_ => _.MealProducts)
                    .ThenInclude(_ => _.Product);
            }

            return query;
        }
    }
}
