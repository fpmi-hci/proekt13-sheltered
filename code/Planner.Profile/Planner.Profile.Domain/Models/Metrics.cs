using System;

namespace Planner.Profile.Domain.Models
{
    public class Metrics
    {
        public Guid MetricId { get; set; }

        public Guid UserId { get; set; }

        public int Height { get; set; }

        public double Weight { get; set; }

        public DateTime Date { get; set; }
    }
}
