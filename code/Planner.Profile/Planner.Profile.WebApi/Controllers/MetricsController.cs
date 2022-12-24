using Microsoft.AspNetCore.Mvc;
using Planner.Profile.Domain.Models;
using Planner.Profile.WebApi.Models.Requests;
using Planner.Profile.WebApi.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Profile.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetricsController : ControllerBase
    {
        //TODO: assign here real user id
        private readonly Guid UserId = Guid.Parse("6bb1c676-0fd8-4591-89c3-75e476104f93");
        private readonly Gender Gender = Gender.Female;

        public MetricsController()
        {

        }

        [HttpGet]
        public Task<ActionResult<MetricsListResponse>> GetMetricsAsync(
            [FromQuery] MetricsRequest request,
            CancellationToken cancellationToken)
        {

        }

        //[HttpPost]
        //public Task<ActionResult> AddNewMetricsAsync(
        //    [FromBody] NewMetricsRequest request,
        //    CancellationToken cancellationToken)
        //{

        //}
    }
}
