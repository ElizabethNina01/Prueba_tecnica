using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using prueba_back.Persistence;
using prueba_back.Resources;
using prueba_back.Services;
using prueba_back.Domain.Services;
using prueba_back.Domain.Repositories;
using Microsoft.AspNetCore.HttpOverrides;
namespace prueba_back
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
        {   services.AddCors();
            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddControllers();
            
             services.AddDbContext<prueba_back.Persistence.AppDbContext>(options =>
            {
                 options.UseSqlServer("Server=DESKTOP-2783G35\\SQLEXPRESS;Database=API_DB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False");
              });
            
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "prueba_back", Version = "v1" });
            });
            services.AddDbContext<prueba_back.Persistence.AppDbContext>();
            
             services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
           services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // For this course purpose we allow Swagger in release mode.
            app.UseDeveloperExceptionPage();
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/swagger/{documentname}/swagger.json";
            });


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/docs/swagger/v1/swagger.json", "prueba-back API v1 Documentation");
                c.RoutePrefix = "docs/swagger";
            });

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

           


            app.UseRouting();


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
