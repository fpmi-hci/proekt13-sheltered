using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Recipes.Domain.Models;

namespace Planner.Recipes.Infrastructure.Configs
{
    public class FavoriteConfig : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorites");

            builder.HasKey(_ => _.FavoriteId);

            builder.HasOne(_ => _.Recipe)
                .WithMany(_ => _.Favorites)
                .HasForeignKey(_ => _.RecipeId);
        }
    }
}
