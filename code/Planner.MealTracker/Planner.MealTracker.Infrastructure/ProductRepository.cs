using Microsoft.EntityFrameworkCore;
using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly MealTrackerDbContext _context;

        public ProductRepository(MealTrackerDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Product entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(
            ProductSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return FilterProducts(searchParameter);
        }

        public Task<Product> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Product> FilterProducts(ProductSearchParameter searchParameter)
        {
            var query = _context.Products
                .AsNoTracking();

            if (!string.IsNullOrEmpty(searchParameter.Filter))
            {
                query = query
                    .Where(_ => _.Name.Contains(searchParameter.Filter));
            }

            return query.OrderBy(_ => _.Name);
        }
    }
}
