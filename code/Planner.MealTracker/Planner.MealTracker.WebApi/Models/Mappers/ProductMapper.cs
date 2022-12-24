using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.WebApi.Models.Requests;
using Planner.MealTracker.WebApi.Models.Responses;

namespace Planner.MealTracker.WebApi.Models.Mappers
{
    public static class ProductMapper
    {
        public static ProductSearchParameter ToDomain(this ProductsRequest request)
        {
            if (request == null)
            {
                return null;
            }

            return new ProductSearchParameter()
            {
                Filter = request.Filter
            };
        }

        public static ProductResponse ToResponse(this Product model)
        {
            if (model == null)
            {
                return null;
            }

            return new ProductResponse()
            {
                Id = model.ProductId,
                Name = model.Name,
                Calories = model.Calories,
                Fats = model.Fats,
                Proteins = model.Proteins
            };
        }
    }
}
