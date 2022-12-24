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
    public class WaterRepository : IWaterRepository
    {
        private readonly MealTrackerDbContext _context;

        public WaterRepository(MealTrackerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Water entity, CancellationToken cancellationToken)
        {
            await _context.Waters.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Water entity, CancellationToken cancellationToken)
        {
            var model = await FilterWater(new WaterSearchParameter()
            {
                UserId = entity.UserId,
                Date = entity.Date.Date
            }).SingleOrDefaultAsync(cancellationToken);

            if (model != null)
            {
                _context.Waters.Remove(model);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Water>> GetAllAsync(
            WaterSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return FilterWater(searchParameter);
        }

        public Task<Water> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Water entity, CancellationToken cancellationToken)
        {
            _context.Waters.Attach(entity);
            _context.Waters.Update(entity);

            return _context.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<Water> FilterWater(WaterSearchParameter searchParameter)
        {
            var query = _context.Waters
                .AsNoTracking()
                .Where(_ => _.UserId.Equals(searchParameter.UserId) && 
                    _.Date.Date.Equals(searchParameter.Date.Date));

            return query;
        }
    }
}
