using Planner.Recipes.Domain.Models;
using Planner.Recipes.WebApi.Models.Requests;
using Planner.Recipes.WebApi.Models.Responses;
using System;
using System.Linq;

namespace Planner.Recipes.WebApi.Mappers
{
    public static class RecipesMapper
    {
        public static SearchParameter ToDomain(this RecipesRequest request, Guid? userId = null)
        {
            if (request == null)
            {
                return null;
            }

            if (userId.HasValue)
            {
                return new FavoritesSearchParameter()
                {
                    Limit = request.Limit,
                    Offset = request.Offset,
                    Filter = request.Filter,
                    UserId = userId.Value
                };
            }

            return new RecipesSearchParameter()
            {
                Limit = request.Limit,
                Offset = request.Offset,
                Filter = request.Filter
            };
        }

        public static RecipeResponse ToResponse(this Recipe recipe)
        {
            if (recipe == null)
            {
                return null;
            }

            return new RecipeResponse()
            {
                Id = recipe.RecipeId,
                Name = recipe.Name,
                ImgUrl = recipe.ImgUrl,
                Calories = recipe.Calories,
                Carbs = recipe.Carbs,
                Fats = recipe.Fats,
                Proteins = recipe.Proteins
            };
        }

        public static RecipeDetailsResponse ToDetailsResponse(this Recipe recipe)
        {
            if (recipe == null)
            {
                return null;
            }

            return new RecipeDetailsResponse()
            {
                Id = recipe.RecipeId,
                Name = recipe.Name,
                ImgUrl = recipe.ImgUrl,
                Calories = recipe.Calories,
                Carbs = recipe.Carbs,
                Fats = recipe.Fats,
                Proteins = recipe.Proteins,
                Time = recipe.Time,
                Products = recipe.ProductPortions
                    .Select(_ => new ProductResponse()
                    {
                        Product = _.Product.Name,
                        Portion = _.Portion
                    }),
                Steps = recipe.Steps
                    .OrderBy(_ => _.Number)
                    .Select(_ => _.Description)
            };
        }
    }
}
