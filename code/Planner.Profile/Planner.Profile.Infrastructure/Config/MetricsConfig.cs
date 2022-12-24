using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Profile.Domain.Models;

namespace Planner.Profile.Infrastructure.Sql.Config
{
    public class MetricsConfig : IEntityTypeConfiguration<Metrics>
    {
        public void Configure(EntityTypeBuilder<Metrics> builder)
        {
            builder.ToTable("Metrics");

            builder.HasKey(_ => _.MetricId);
            builder.Property(_ => _.Date).HasColumnType("datetime2");
        }
    }
}
