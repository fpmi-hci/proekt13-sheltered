using Microsoft.AspNetCore.Mvc;
using Planner.MealTracker.Domain.Core;
using Planner.MealTracker.Domain.Models.Search;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterController : ControllerBase
    {
        //TODO: assign here real user id
        private readonly Guid UserId = Guid.Parse("6bb1c676-0fd8-4591-89c3-75e476104f93");

        private readonly IWaterService _service;

        public WaterController(IWaterService service)
        {
            _service = service;
        }

        [HttpGet("{date:DateTime}")]
        public async Task<ActionResult<int>> GetWaterAsync(
            [FromRoute] DateTime date,
            CancellationToken cancellationToken)
        {
            var searchParameter = new WaterSearchParameter()
            {
                Date = date,
                UserId = UserId
            };

            var result = await _service.GetWaterAsync(
                searchParameter, 
                cancellationToken);

            var response = 0;

            if (result != null)
            {
                response = result.Cups;
            }

            return Ok(response);
        }


        [HttpPost("{date:DateTime}")]
        public async Task<ActionResult> AddWaterAsync(
            [FromRoute] DateTime date,
            CancellationToken cancellationToken)
        {
            var searchParameter = new WaterSearchParameter()
            {
                Date = date,
                UserId = UserId
            };

            await _service.AddWaterCupAsync(searchParameter, cancellationToken);

            return Ok();
        }

        [HttpDelete("{date:DateTime}")]
        public async Task<ActionResult> RemoveWaterAsync(
            [FromRoute] DateTime date,
            CancellationToken cancellationToken)
        {
            var searchParameter = new WaterSearchParameter()
            {
                Date = date,
                UserId = UserId
            };

            await _service.RemoveWaterAsync(searchParameter, cancellationToken);

            return Ok();
        }
    }
}
