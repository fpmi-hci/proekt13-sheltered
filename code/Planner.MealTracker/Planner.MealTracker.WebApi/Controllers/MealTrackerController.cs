using Microsoft.AspNetCore.Mvc;
using Planner.MealTracker.Domain.Core;
using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.WebApi.Models.Mappers;
using Planner.MealTracker.WebApi.Models.Requests;
using Planner.MealTracker.WebApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealTrackerController : Controller
    {
        //TODO: assign here real user id
        private readonly Guid UserId = Guid.Parse("6bb1c676-0fd8-4591-89c3-75e476104f93");

        private readonly IMealTrackerService _service;

        public MealTrackerController(IMealTrackerService service)
        {
            _service = service;
        }

        [HttpGet("goal")]
        public async Task<ActionResult<Goal>> GetGoalAsync(
            CancellationToken cancellationToken)
        {
            var searchParameter = new GoalSearchParameter()
            {
                UserId = UserId
            };

            var result = await _service.GetUserGoalAsync(
                searchParameter, 
                cancellationToken);

            return Ok(result);
        }

        [HttpGet("progress/{date:DateTime}")]
        public async Task<ActionResult<DailyProgress>> GetDailyProgressAsync(
            [FromRoute] DateTime date,
            CancellationToken cancellationToken)
        {
            var searchParameter = new DailyProgressSearchParameter()
            {
                UserId = UserId,
                Date = date
            };

            var result = await _service.GetUserDailyProgressAsync(
                searchParameter, 
                cancellationToken);

            return Ok(result);
        }

        [HttpGet("meals")]
        public async Task<ActionResult<MealResponse>> GetMealAsync(
            [FromQuery] MealRequest request,
            CancellationToken cancellationToken)
        {
            var searchParameter = request.ToDomain(UserId);

            var result = await _service.GetDailyMealAsync(
                searchParameter, 
                cancellationToken);

            return Ok(result.ToResponse());
        }

        [HttpPost("add")]
        public async Task<ActionResult<MealResponse>> AddProductsAsync(
            [FromBody] MealProductsAddRequest request,
            CancellationToken cancellationToken)
        {
            (var searchParameter, var products) = request.ToDomain(UserId);

            var result = await _service.AddMealProductsAsync(
                searchParameter,
                products,
                cancellationToken);

            return Ok(result.ToResponse());
        }

        [HttpPost("remove")]
        public async Task<ActionResult<MealResponse>> RemoveProductsAsync(
            [FromBody] MealProductsRemoveRequest request,
            CancellationToken cancellationToken)
        {
            (var searchParameter, var products) = request.ToDomain(UserId);

            var result = await _service.RemoveMealProductsAsync(
                searchParameter,
                products,
                cancellationToken);

            return Ok(result.ToResponse());
        }
    }
}
