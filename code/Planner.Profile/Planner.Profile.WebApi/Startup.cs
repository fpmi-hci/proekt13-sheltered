using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Planner.Profile.Domain.Core;
using Planner.Profile.DomainServices;
using Planner.Profile.Infrastructure.Sql;
using Planner.Profile.Infrastructure.Sql.Core;

namespace Planner.Profile.WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planner.Profile.WebApi", Version = "v1" });
            });

            ConfigureInfrastructure(services);
            ConfigureDomainServices(services);
        }

        public void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddDbContext<ProfileDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProfileDbContext")));

            services.AddScoped<IMetricsRepository, MetricsRepository>();
        }

        public void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<IMetricsService, MetricsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planner.Profile.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
