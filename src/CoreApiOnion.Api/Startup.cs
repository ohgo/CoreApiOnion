using CoreApiOnion.Api.Services;
using CoreApiOnion.Core.Interfaces;
using CoreApiOnion.Infrastructure.Databases;
using CoreApiOnion.Infrastructure.ExternalApis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreApiOnion.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMonthlyGradeRepository, MonthlyGradeRepository>();
            services.AddTransient<ITripGradeRepository, TripGradeRepository>();
            services.AddTransient<IAggregationService, AggregationService>();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("docs", new Info { Title = "CoreApiOnion" });
            });

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/docs/swagger.json", "CoreApiOnion");
            });

            app.UseMvc();
        }
    }
}
