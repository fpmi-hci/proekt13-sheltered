using Planner.Profile.Domain.Models;
using Planner.Profile.Domain.Models.Search;

namespace Planner.Profile.Infrastructure.Sql.Core
{
    public interface IMetricsRepository : IGenericAsyncRepository<Metrics, MetricsSearchParameter>
    {
    }
}
