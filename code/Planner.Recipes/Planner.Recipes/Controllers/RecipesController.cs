using Microsoft.AspNetCore.Mvc;
using Planner.Recipes.Domain.Core;
using Planner.Recipes.WebApi.Mappers;
using Planner.Recipes.WebApi.Models.Requests;
using Planner.Recipes.WebApi.Models.Responses;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Recipes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesService;

        //TODO: assign here real user id
        private readonly Guid UserId = Guid.Parse("6bb1c676-0fd8-4591-89c3-75e476104f93");

        public RecipesController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public async Task<ActionResult<RecipesResponse>> GetRecipesAsync(
            [FromQuery] RecipesRequest request, 
            CancellationToken cancellationToken)
        {
            var searchParameter = request.ToDomain(request.Favorites
                ? UserId
                : null);

            var count = await _recipesService.GetRecipesTotalCountAsync(
                searchParameter, 
                cancellationToken);

            var result = await _recipesService.GetRecipesAsync(
                searchParameter, 
                cancellationToken);

            var response = new RecipesResponse()
            {
                Count = count,
                Recipes = result
                    .Select(_ => _.ToResponse())
            };

            return Ok(response);
        }

        [HttpGet("{recipeId:guid}")]
        public async Task<ActionResult<RecipeResponse>> GetRecipeDetailsAsync(
            [FromRoute] Guid recipeId, 
            CancellationToken cancellationToken)
        {
            var result = await _recipesService
                .GetRecipeDetailsAsync(recipeId, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.ToDetailsResponse());
        }

        [HttpPost]
        public async Task<ActionResult> PostFavoriteRecipeAsync(
            [FromBody] FavoriteRequest request, 
            CancellationToken cancellationToken)
        {
            //TODO: replace with real user id
            await _recipesService.AddRecipeToFavoritesAsync(
                request.RecipeId, 
                UserId, 
                cancellationToken);

            return Ok();
        }

        [HttpDelete("{recipeId:guid}")]
        public async Task<ActionResult> DeleteFavoriteRecipeAsync(
            [FromRoute] Guid recipeId,
            CancellationToken cancellationToken)
        {
            //TODO: replace with real user id
            await _recipesService.RemoveRecipeFromFavoritesAsync(
                recipeId, 
                UserId, 
                cancellationToken);

            return Ok();
        }
    }
}
