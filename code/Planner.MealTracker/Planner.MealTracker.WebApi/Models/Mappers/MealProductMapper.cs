using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.WebApi.Models.Requests;
using Planner.MealTracker.WebApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Planner.MealTracker.WebApi.Models.Mappers
{
    public static class MealProductMapper
    {
        public static MealProductResponse ToResponse(this MealProduct model)
        {
            if (model == null)
            {
                return null;
            }

            return new MealProductResponse()
            {
                Id = model.MealProductId,
                Name = model?.Product.Name,
                Calories = model.Product.Calories,
                Carbs = model.Product.Carbs,
                Fats = model.Product.Fats,
                Proteins = model.Product.Proteins,
                Weight = model.Weight
            };
        }

        public static (MealSearchParameter, IEnumerable<MealProduct>) ToDomain(
            this MealProductsAddRequest request,
            Guid userId)
        {
            if (request == null)
            {
                return (null, null);
            }

            var searchParameter = new MealSearchParameter()
            {
                Type = request.Type,
                Date = request.Date,
                UserId = userId
            };

            var mealProducts = request.Products
                .Select(_ => new MealProduct()
                {
                    ProductId = _.Id,
                    Weight = _.Weight
                });

            return (searchParameter, mealProducts);
        }

        public static (MealSearchParameter, IEnumerable<MealProduct>) ToDomain(
            this MealProductsRemoveRequest request, 
            Guid userId)
        {
            if (request == null)
            {
                return (null, null);
            }

            var searchParameter = new MealSearchParameter()
            {
                Type = request.Type,
                Date = request.Date,
                UserId = userId
            };

            var mealProducts = request.Products
                .Select(_ => new MealProduct()
                {
                    MealProductId = _
                });

            return (searchParameter, mealProducts);
        }
    }
}
