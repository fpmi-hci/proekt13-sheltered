using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.Domain.Core
{
    public interface IMealTrackerService
    {
        Task<Goal> GetUserGoalAsync(GoalSearchParameter searchParameter, CancellationToken cancellationToken);

        Task<DailyProgress> GetUserDailyProgressAsync(DailyProgressSearchParameter searchParameter, CancellationToken cancellationToken);

        Task<Meal> GetDailyMealAsync(MealSearchParameter searchParameter, CancellationToken cancellationToken);

        Task<Meal> AddMealProductsAsync(MealSearchParameter searchParameter, IEnumerable<MealProduct> products, CancellationToken cancellationToken);

        Task<Meal> RemoveMealProductsAsync(MealSearchParameter searchParameter, IEnumerable<MealProduct> products, CancellationToken cancellationToken);
    }
}
