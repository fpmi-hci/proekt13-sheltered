using Planner.Recipes.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Recipes.Infrastructure.Core
{
    public interface IFavoritesRepository : IGenericAsyncRepository<Favorite, FavoritesSearchParameter>
    {
        Task<int> CountAsync(FavoritesSearchParameter searchParameter, CancellationToken cancellationToken);
    }
}
