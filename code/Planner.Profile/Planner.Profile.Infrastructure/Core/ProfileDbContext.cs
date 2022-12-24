using Microsoft.EntityFrameworkCore;
using Planner.Profile.Domain.Models;
using Planner.Profile.Infrastructure.Sql.Config;

namespace Planner.Profile.Infrastructure.Sql.Core
{
    public class ProfileDbContext : DbContext
    {
        public virtual DbSet<Metrics> Metrics { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MetricsConfig());
        }
    }
}
