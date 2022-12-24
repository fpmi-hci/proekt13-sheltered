using Planner.Profile.Domain.Core;
using Planner.Profile.Domain.Models;
using Planner.Profile.Domain.Models.Search;
using Planner.Profile.Infrastructure.Sql.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Profile.DomainServices
{
    public class MetricsService : IMetricsService
    {
        private readonly IMetricsRepository _repository;

        public MetricsService(IMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task AddNewMetricsAsync(
            Metrics metrics, 
            Goal goal, 
            CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Metrics>> GetMetricsAsync(
            MetricsSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
