using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.MealTracker.Domain.Models;

namespace Planner.MealTracker.Infrastructure.Configs
{
    public class WaterConfig : IEntityTypeConfiguration<Water>
    {
        public void Configure(EntityTypeBuilder<Water> builder)
        {
            builder.ToTable("Waters");

            builder.HasKey(_ => _.WaterId);

            builder
                .Property(_ => _.Date)
                .HasColumnType("datetime2");
        }
    }
}
