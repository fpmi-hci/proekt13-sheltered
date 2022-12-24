using Planner.Profile.Domain.Models;

namespace Planner.Profile.WebApi.Models.Requests
{
    public class NewMetricsRequest
    {
        public double Weight { get; set; }

        public int Height { get; set; }

        public Goal Goal { get; set; }
    }
}
