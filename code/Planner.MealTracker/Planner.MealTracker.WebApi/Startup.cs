using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Planner.MealTracker.Domain.Core;
using Planner.MealTracker.DomainServices;
using Planner.MealTracker.Infrastructure;
using Planner.MealTracker.Infrastructure.Core;

namespace Planner.MealTracker.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planner.MealTracker.WebApi", Version = "v1" });
            });

            ConfigureInfrastructure(services);
            ConfigureDomainServices(services);
        }

        public void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddDbContext<MealTrackerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MealTrackerDbContext")));

            services.AddScoped<IWaterRepository, WaterRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IMealProductRepository, MealProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<IWaterService, WaterService>();
            services.AddScoped<IMealTrackerService, MealTrackerService>();
            services.AddScoped<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planner.MealTracker.WebApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
