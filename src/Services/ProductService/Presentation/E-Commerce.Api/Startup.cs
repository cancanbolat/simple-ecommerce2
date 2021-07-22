using AspNetCoreRateLimit;
using E_Commerce.Application;
using E_Commerce.Persistence;
using E_Commerce.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api
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
            // DI
            services.AddConfigureApplication();
            services.AddConfigurePersistence();

            // Database
            services.AddDbContext<ECommerceDbContext>(db =>
            {
                db.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();

            #region CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });
            #endregion

            #region Authentication
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", op =>
                {
                    op.RequireHttpsMetadata = false;
                    op.Authority = "https://localhost:1001";
                    op.Audience = "ECommerceAPI";
                });
            #endregion

            #region Healthchecks
            services.AddHealthChecks().AddElasticsearch(Configuration["ElasticConfiguration:Uri"]);
            services.AddHealthChecks()
                    .AddSqlServer(Configuration.GetConnectionString("SqlServer"),
                    "SELECT 1",
                    $"Sql => { Configuration.GetConnectionString("SqlServer").Split(";").First() }",
                    HealthStatus.Degraded,
                    timeout: TimeSpan.FromSeconds(30),
                    tags: new[] { "db", "sql", "sqlserver" }
                );
            #endregion

            #region Versioning
            services.AddApiVersioning(v =>
            {
                v.DefaultApiVersion = new ApiVersion(1, 0);
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.ReportApiVersions = true;
            });
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E_Commerce.Api", Version = "v1" });
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "E_Commerce.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            #region Healthcheck options
            app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                ResponseWriter = async (c, r) =>
                {
                    c.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(new
                    {
                        status = r.Status.ToString(),
                        components = r.Entries.Select(x => new { key = x.Key, value = x.Value.Status.ToString() })
                    });
                    await c.Response.WriteAsync(result);
                }
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
