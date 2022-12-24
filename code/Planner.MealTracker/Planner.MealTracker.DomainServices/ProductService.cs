using Planner.MealTracker.Domain.Core;
using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.Infrastructure.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.DomainServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> GetProductsAsync(
            ProductSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return _repository.GetAllAsync(searchParameter, cancellationToken);
        }
    }
}
