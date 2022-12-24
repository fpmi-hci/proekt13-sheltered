using System;

namespace Planner.Profile.Domain.Models.Search
{
    public class MetricsSearchParameter
    {
        public Guid UserId { get; set; }

        public int Offset { get; set; } = 0;

        public int Limit { get; set; } = 100;

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
