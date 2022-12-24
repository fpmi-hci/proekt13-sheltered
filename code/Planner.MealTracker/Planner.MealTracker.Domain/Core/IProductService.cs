using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.Domain.Core
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(ProductSearchParameter searchParameter, CancellationToken cancellationToken);
    }
}
