using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.MealTracker.Domain.Models;

namespace Planner.MealTracker.Infrastructure.Configs
{
    public class MealConfig : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.ToTable("Meals");

            builder.HasKey(_ => _.MealId);

            builder
                .Property(_ => _.Date)
                .HasColumnType("datetime2");

            builder
                .Property(_ => _.Type)
                .HasColumnType("tinyint");

            builder
                .HasMany(_ => _.MealProducts)
                .WithOne(_ => _.Meal)
                .HasForeignKey(_ => _.MealId) ;
        }
    }
}
