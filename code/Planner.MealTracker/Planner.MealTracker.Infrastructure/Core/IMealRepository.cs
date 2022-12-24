using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.Infrastructure.Core
{
    public interface IMealRepository : IGenericAsyncRepository<Meal, MealSearchParameter>
    {
        Task AttachAsync(Meal entity, CancellationToken cancellationToken);
    }
}
