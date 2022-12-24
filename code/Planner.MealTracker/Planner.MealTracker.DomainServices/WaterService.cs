using Planner.MealTracker.Domain.Core;
using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Domain.Models.Search;
using Planner.MealTracker.Infrastructure.Core;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.MealTracker.DomainServices
{
    public class WaterService : IWaterService
    {
        private readonly IWaterRepository _repository;

        public WaterService(IWaterRepository repository)
        {
            _repository = repository;
        }

        public async Task AddWaterCupAsync(
            WaterSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            var model = await GetWaterAsync(searchParameter, cancellationToken);

            if (model == null)
            {
                model = new Water()
                {
                    UserId = searchParameter.UserId,
                    Date = searchParameter.Date.Date,
                    Cups = 1
                };

                await _repository.CreateAsync(model, cancellationToken);
            }
            else
            {
                model.Cups++;
                await _repository.UpdateAsync(model, cancellationToken);
            }
        }

        public async Task<Water> GetWaterAsync(
            WaterSearchParameter searchParameter, 
            CancellationToken cancellationToken)
        {
            return (await _repository
                .GetAllAsync(searchParameter, cancellationToken))
                .SingleOrDefault();
        }

        public async Task RemoveWaterAsync(WaterSearchParameter searchParameter, CancellationToken cancellationToken)
        {
            var model = await GetWaterAsync(searchParameter, cancellationToken);

            if (model != null)
            {
                if (model.Cups == 1)
                {
                    await _repository.DeleteAsync(model, cancellationToken);
                }
                else
                {
                    model.Cups--;
                    await _repository.UpdateAsync(model, cancellationToken);
                }
            }
        }
    }
}
