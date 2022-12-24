using System;

namespace Planner.Profile.WebApi.Models.Requests
{
    public class MetricsRequest
    {
        public int Offset { get; set; } = 0;

        public int Limit { get; set; } = 100;

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
