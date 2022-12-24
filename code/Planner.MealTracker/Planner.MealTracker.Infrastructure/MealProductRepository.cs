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
    public class MealProductRepository : IMealProductRepository
    {
        private readonly MealTrackerDbContext _context;

        public MealProductRepository(MealTrackerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(
            MealProduct entity, 
            CancellationToken cancellationToken)
        {
            await _context.MealProducts.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(
            MealProduct entity, 
            CancellationToken cancellationToken)
        {
            _context.MealProducts.Remove(entity);
        }

        public async Task<IEnumerable<MealProduct>> GetAllAsync(
            MealProductSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return FilterMealProducts(searchParameter);
        }

        public Task<MealProduct> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MealProduct entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<MealProduct> FilterMealProducts(MealProductSearchParameter searchParameter)
        {
            var query = _context.MealProducts
                .AsNoTracking()
                .Where(_ => _.MealId.Equals(searchParameter.MealId))
                .Include(_ => _.Product);

            return query;
        }
    }
}
