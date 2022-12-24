using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.Domain.Core
{
    public interface IWaterService
    {
        Task<Water> GetWaterAsync(WaterSearchParameter searchParameter, CancellationToken cancellationToken);

        Task AddWaterCupAsync(WaterSearchParameter searchParameter, CancellationToken cancellationToken);

        Task RemoveWaterAsync(WaterSearchParameter searchParameter, CancellationToken cancellationToken);
    }
}
