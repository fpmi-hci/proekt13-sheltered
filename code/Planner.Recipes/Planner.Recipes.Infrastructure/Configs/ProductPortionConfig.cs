using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Recipes.Domain.Models;

namespace Planner.Recipes.Infrastructure.Configs
{
    public class ProductPortionConfig : IEntityTypeConfiguration<ProductPortion>
    {
        public void Configure(EntityTypeBuilder<ProductPortion> builder)
        {
            builder.ToTable("ProductPortions");

            builder.HasKey(_ => _.ProductPortionId);

            builder.HasOne(_ => _.Product)
                .WithMany(_ => _.ProductPortions)
                .HasForeignKey(_ => _.ProductId);

            builder.HasOne(_ => _.Recipe)
                .WithMany(_ => _.ProductPortions)
                .HasForeignKey(_ => _.RecipeId);
        }
    }
}
