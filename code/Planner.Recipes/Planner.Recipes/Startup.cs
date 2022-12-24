using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Planner.Recipes.Domain.Core;
using Planner.Recipes.DomainServices;
using Planner.Recipes.Infrastructure;
using Planner.Recipes.Infrastructure.Core;
using Planner.Recipes.Infrastructure.Infrastructure;

namespace Planner.Recipes
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
            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "weatherapi";
                    options.Authority = "https://localhost:5001";
                });

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planner.Recipes", Version = "v1" });
            });

            ConfigureInfrastructure(services);
            ConfigureDomainServices(services);
        }

        public void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddDbContext<RecipesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RecipesDbContext")));

            services.AddScoped<IRecipesRepository, RecipesRepository>();
            services.AddScoped<IFavoritesRepository, FavoritesRepository>();
        }

        public void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<IRecipesService, RecipesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planner.Recipes v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
