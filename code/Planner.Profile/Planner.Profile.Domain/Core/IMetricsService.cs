using Planner.Profile.Domain.Models;
using Planner.Profile.Domain.Models.Search;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Profile.Domain.Core
{
    public interface IMetricsService
    {
        Task<IEnumerable<Metrics>> GetMetricsAsync(MetricsSearchParameter searchParameter, CancellationToken cancellationToken);

        Task AddNewMetricsAsync(Metrics metrics, Goal goal, CancellationToken cancellationToken);
    }
}
