using Microsoft.AspNetCore.Mvc;
using Planner.MealTracker.Domain.Core;
using Planner.MealTracker.WebApi.Models.Mappers;
using Planner.MealTracker.WebApi.Models.Requests;
using Planner.MealTracker.WebApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        //TODO: assign here real user id
        private readonly Guid UserId = Guid.Parse("6bb1c676-0fd8-4591-89c3-75e476104f93");

        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProductListAsync(
            [FromQuery] ProductsRequest request,
            CancellationToken cancellationToken)
        {
            var searchParameter = request.ToDomain();

            var result = await _service.GetProductsAsync(
                searchParameter,
                cancellationToken);

            var response = result
                .Select(_ => _.ToResponse());

            return Ok(response);
        }
    }
}
