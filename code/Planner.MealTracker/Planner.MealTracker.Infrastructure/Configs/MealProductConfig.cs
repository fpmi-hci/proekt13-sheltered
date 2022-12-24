using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.MealTracker.Domain.Models;

namespace Planner.MealTracker.Infrastructure.Configs
{
    public class MealProductConfig : IEntityTypeConfiguration<MealProduct>
    {
        public void Configure(EntityTypeBuilder<MealProduct> builder)
        {
            builder.ToTable("MealProducts");

            builder.HasKey(_ => _.MealProductId);

            builder
                .HasOne(_ => _.Product)
                .WithMany(_ => _.MealProducts)
                .HasForeignKey(_ => _.ProductId);
        }
    }
}
