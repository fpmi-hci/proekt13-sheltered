using Microsoft.EntityFrameworkCore;
using Planner.MealTracker.Domain.Models;
using Planner.MealTracker.Infrastructure.Configs;

namespace Planner.MealTracker.Infrastructure.Core
{
    public class MealTrackerDbContext : DbContext
    {
        public virtual DbSet<Meal> Meals { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<MealProduct> MealProducts { get; set; }

        public virtual DbSet<Water> Waters { get; set; }

        public virtual DbSet<Goal> Goals { get; set; }

        public MealTrackerDbContext(DbContextOptions<MealTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MealConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new MealProductConfig());
            modelBuilder.ApplyConfiguration(new WaterConfig());
            modelBuilder.ApplyConfiguration(new GoalConfig());
        }
    }
}
