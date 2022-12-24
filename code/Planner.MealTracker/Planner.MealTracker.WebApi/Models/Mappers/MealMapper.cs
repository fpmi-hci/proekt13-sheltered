using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.WebApi.Models.Requests;
using Planner.MealTracker.WebApi.Models.Responses;
using System;
using System.Linq;

namespace Planner.MealTracker.WebApi.Models.Mappers
{
    public static class MealMapper
    {
        public static MealSearchParameter ToDomain(this MealRequest request, Guid userId)
        {
            if (request == null)
            {
                return null;
            }

            return new MealSearchParameter()
            {
                UserId = userId,
                Date = request.Date.Date,
                Type = request.Type
            };
        }

        public static MealResponse ToResponse(this Meal model)
        {
            if (model == null)
            {
                return null;
            }

            return new MealResponse()
            {
                Id = model.MealId,
                Date = model.Date,
                Type = model.Type,
                Products = model.MealProducts
                    .Select(_ => _.ToResponse())
            };
        }
    }
}
