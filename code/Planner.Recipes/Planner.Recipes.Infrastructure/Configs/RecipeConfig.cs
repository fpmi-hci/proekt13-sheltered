using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Recipes.Domain.Models;

namespace Planner.Recipes.Infrastructure.Configs
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes");

            builder.HasKey(_ => _.RecipeId);

            builder.HasMany(_ => _.Steps)
                .WithOne(_ => _.Recipe)
                .HasForeignKey(_ => _.RecipeId);
        }
    }
}
