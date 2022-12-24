using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;

namespace Planner.MealTracker.Infrastructure.Core
{
    public interface IWaterRepository : IGenericAsyncRepository<Water, WaterSearchParameter>
    {
    }
}
