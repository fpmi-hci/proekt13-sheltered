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
    public class GoalRepository : IGoalRepository
    {
        private readonly MealTrackerDbContext _context;

        public GoalRepository(MealTrackerDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Goal entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Goal entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Goal>> GetAllAsync(
            GoalSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return FilterGoals(searchParameter);
        }

        public Task<Goal> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Goal entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Goal> FilterGoals(GoalSearchParameter searchParameter)
        {
            var query = _context.Goals
                .AsNoTracking()
                .Where(_ => _.UserId.Equals(searchParameter.UserId));

            return query;
        }
    }
}
