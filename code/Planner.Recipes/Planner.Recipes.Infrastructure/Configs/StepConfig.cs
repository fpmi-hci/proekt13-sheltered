using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Recipes.Domain.Models;

namespace Planner.Recipes.Infrastructure.Configs
{
    public class StepConfig : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("Steps");
            builder.HasKey(_ => _.StepId);
        }
    }
}
