using System.IO;
using CoreApiOnion.Api.Interfaces;
using CoreApiOnion.Api.Repositories;
using CoreApiOnion.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
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
            services.AddTransient<IService, Service>();
            services.AddTransient<IExternalApiRepository, ExternalApiRepository>();
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("docs", new Info { Title = "CoreApiOnion" });

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "CoreApiOnion.Api.xml");
                c.IncludeXmlComments(filePath);
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
