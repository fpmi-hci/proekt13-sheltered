using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.Infrastructure.Core
{
    public interface IGenericAsyncRepository<T, U>
    {
        Task<T> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<T>> GetAllAsync(U searchParameter, CancellationToken cancellationToken);

        Task CreateAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
