using Microsoft.EntityFrameworkCore;
using Planner.Recipes.Domain.Models;
using Planner.Recipes.Infrastructure.Configs;

namespace Planner.Recipes.Infrastructure.Infrastructure
{
    public class RecipesDbContext : DbContext
    {
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPortion> ProductPortions { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductPortionConfig());
            modelBuilder.ApplyConfiguration(new StepConfig());
            modelBuilder.ApplyConfiguration(new FavoriteConfig());
        }
    }
}
