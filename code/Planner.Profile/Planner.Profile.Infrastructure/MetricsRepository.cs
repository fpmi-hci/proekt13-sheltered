using Microsoft.EntityFrameworkCore;
using Planner.Profile.Domain.Models;
using Planner.Profile.Domain.Models.Search;
using Planner.Profile.Infrastructure.Sql.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Profile.Infrastructure.Sql
{
    public class MetricsRepository : IMetricsRepository
    {
        private readonly ProfileDbContext _context;

        public MetricsRepository(ProfileDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Metrics entity, CancellationToken cancellationToken)
        {
            await _context.Metrics.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(Metrics entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Metrics>> GetAllAsync(
            MetricsSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return FilterMetrics(searchParameter);
        }

        public Task<Metrics> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Metrics entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Metrics> FilterMetrics(MetricsSearchParameter searchParameter)
        {
            var query = _context.Metrics
                .AsNoTracking()
                .Where(_ => _.UserId.Equals(searchParameter.UserId));

            if (searchParameter.Start.HasValue)
            {
                query = query.Where(_ => _.Date >= searchParameter.Start.Value);
            }

            if (searchParameter.End.HasValue)
            {
                query = query.Where(_ => _.Date <= searchParameter.End.Value);
            }

            return query
                .Skip(searchParameter.Offset)
                .Take(searchParameter.Limit);
        }
    }
}
