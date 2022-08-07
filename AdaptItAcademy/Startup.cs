using AdaptItAcademy.BusinessLogic;
using AdaptItAcademy.BusinessLogic.BusinessLogic;
using AdaptItAcademy.Configuration;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy
{
    public class Startup
    {
        private readonly string corsPolicy = "CorsPolicy";
        private AppConfiguration appConfiguration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            appConfiguration = new AppConfiguration(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<AppConfiguration>();
            services.AddScoped<ICouserBusinessLogic, CouserBusinessLogic>(sp => new CouserBusinessLogic(appConfiguration.Connection));
            services.AddScoped<IBusinesLogicTraining, BusinesLogicTraining>(sp => new BusinesLogicTraining(appConfiguration.Connection));
            services.AddScoped<IBusinessLogicCandidate, BusinessLogicCandidate>(sp => new BusinessLogicCandidate(appConfiguration.Connection));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(appConfiguration.Version, new OpenApiInfo
                {
                    Title = appConfiguration.Name,
                    Version = appConfiguration.Version,
                    Description = appConfiguration.Version
                   

                });
            });
        }

        private void CorsSetup(CorsOptions options)
        {
            options.AddPolicy(corsPolicy,
                builder =>
                {
                    builder.WithOrigins(appConfiguration.CorsPolicy.Split(',', StringSplitOptions.RemoveEmptyEntries))
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{appConfiguration.ServerAddress}/swagger/{appConfiguration.Version}/swagger.json", 
                    $"{appConfiguration.Name} API {appConfiguration.Version}");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

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
