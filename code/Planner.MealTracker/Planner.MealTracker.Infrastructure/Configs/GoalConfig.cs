using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.MealTracker.Domain.Models;

namespace Planner.MealTracker.Infrastructure.Configs
{
    public class GoalConfig : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.ToTable("Goals");

            builder.HasKey(_ => _.GoalId);
        }
    }
}
