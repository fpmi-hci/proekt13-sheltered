using Planner.Recipes.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Recipes.Infrastructure.Core
{
    public interface IRecipesRepository : IGenericAsyncRepository<Recipe, RecipesSearchParameter>
    {
        Task<int> CountAsync(RecipesSearchParameter searchParameter, CancellationToken cancellationToken);
    }
}
