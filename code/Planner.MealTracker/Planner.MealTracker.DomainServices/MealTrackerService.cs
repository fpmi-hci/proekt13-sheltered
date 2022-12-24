using Planner.MealTracker.Domain.Core;
using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.DomainServices
{
    public class MealTrackerService : IMealTrackerService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMealRepository _mealRepository;
        private readonly IMealProductRepository _mealProductRepository;

        public MealTrackerService(
            IGoalRepository goalRepository,
            IMealRepository mealRepository,
            IMealProductRepository mealProductRepository)
        {
            _goalRepository = goalRepository;
            _mealRepository = mealRepository;
            _mealProductRepository = mealProductRepository;
        }

        public async Task<Meal> AddMealProductsAsync(
            MealSearchParameter searchParameter, 
            IEnumerable<MealProduct> products, 
            CancellationToken cancellationToken)
        {
            searchParameter.IncludeProducts = false;

            var meal = await GetMealAsync(searchParameter, cancellationToken);

            if (meal == null)
            {
                meal = GetDefaultMeal(searchParameter);

                await _mealRepository.CreateAsync(meal, cancellationToken);
                await _mealRepository.AttachAsync(meal, cancellationToken);
            }

            var tasks = products
                .Select(_ =>
                {
                    _.MealId = meal.MealId;
                    return _mealProductRepository.CreateAsync(_, cancellationToken);
                });

            await Task.WhenAll(tasks);
            await _mealProductRepository.CommitAsync(cancellationToken);    

            await LoadMealProductsAsync(meal, cancellationToken);

            return meal;
        }

        public async Task<Meal> RemoveMealProductsAsync(
            MealSearchParameter searchParameter, 
            IEnumerable<MealProduct> products, 
            CancellationToken cancellationToken)
        {
            searchParameter.IncludeProducts = false;

            var meal = await GetMealAsync(searchParameter, cancellationToken);

            if (meal != null)
            {
                var tasks = products
                    .Select(_ => _mealProductRepository
                        .DeleteAsync(_, cancellationToken));

                await Task.WhenAll(tasks);
                await _mealProductRepository.CommitAsync(cancellationToken);

                await LoadMealProductsAsync(meal, cancellationToken);
            }
            else
            {
                meal = GetDefaultMeal(searchParameter);
            }

            return meal;
        }

        public async Task<Meal> GetDailyMealAsync(
            MealSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            searchParameter.IncludeProducts = true;

            var meal = await GetMealAsync(searchParameter, cancellationToken);

            if (meal == null)
            {
                meal = GetDefaultMeal(searchParameter);
            }

            return meal;
        }

        public async Task<DailyProgress> GetUserDailyProgressAsync(
            DailyProgressSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            var mealSearchParameter = new MealSearchParameter()
            {
                UserId = searchParameter.UserId,
                Date = searchParameter.Date,
                IncludeProducts = true
            };

            var result = new DailyProgress()
            {
                UserId = searchParameter.UserId,
                Date = searchParameter.Date,
                Calories = 0,
                Carbs = 0,
                Fats = 0,
                Proteins = 0
            };

            var meals = await _mealRepository.GetAllAsync(
                mealSearchParameter, 
                cancellationToken);

            foreach (var meal in meals)
            {
                foreach (var mealProduct in meal.MealProducts)
                {
                    var portion = (double) mealProduct.Weight / mealProduct.Product.Portion;

                    result.Calories += CountRoundedTotalNutrient(
                        portion, 
                        mealProduct.Product.Calories);

                    result.Carbs += CountRoundedTotalNutrient(
                        portion,
                        mealProduct.Product.Carbs);

                    result.Fats += CountRoundedTotalNutrient(
                        portion,
                        mealProduct.Product.Fats);

                    result.Proteins += CountRoundedTotalNutrient(
                        portion,
                        mealProduct.Product.Proteins);
                }
            }

            return result;
        }

        public async Task<Goal> GetUserGoalAsync(
            GoalSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            var result = (await _goalRepository
                .GetAllAsync(searchParameter, cancellationToken))
                .FirstOrDefault();

            if (result == null)
            {
                result = new Goal();
            }

            return result;
        }

        private double CountTotalNutrient(double portions, double nutrientPerPortion)
        {
            return portions * nutrientPerPortion;
        }

        private int CountRoundedTotalNutrient(double portions, double nutrientPerPortion)
        {
            return (int)Math.Ceiling(CountTotalNutrient(portions, nutrientPerPortion));
        }

        private async Task<Meal> GetMealAsync(
            MealSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return (await _mealRepository
                .GetAllAsync(searchParameter, cancellationToken))
                .FirstOrDefault();
        }

        private Meal GetDefaultMeal(MealSearchParameter searchParameter)
        {
            var meal = new Meal()
            {
                UserId = searchParameter.UserId,
                Date = searchParameter.Date.Date,
                MealProducts = new List<MealProduct>()
            };

            if (searchParameter.Type.HasValue)
            {
                meal.Type = searchParameter.Type.Value;
            }

            return meal;
        }

        private async Task LoadMealProductsAsync(
            Meal meal, 
            CancellationToken cancellationToken)
        {
            meal.MealProducts = (await _mealProductRepository.GetAllAsync(
                   new MealProductSearchParameter() 
                   { 
                       MealId = meal.MealId 
                   },
                   cancellationToken))
                .OrderBy(_ => _.Product.Name)
                .Select(_ =>
                {
                    var portion = (double)_.Weight / _.Product.Portion;

                    _.Product.Calories = CountRoundedTotalNutrient(portion, _.Product.Calories);
                    _.Product.Carbs = CountTotalNutrient(portion, _.Product.Carbs);
                    _.Product.Fats = CountTotalNutrient(portion, _.Product.Fats);
                    _.Product.Proteins = CountTotalNutrient(portion, _.Product.Proteins);

                    return _;
                });
        }
    }
}
