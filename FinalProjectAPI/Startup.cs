using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Core.ApplicationService;
using FinalProject.Core.ApplicationService.Services;
using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using FinalProject.Infrastructure.Data;
using FinalProject.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FinalProjectAPI
{
    public class Startup
    {
        public IHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<ErrorContext>(
                opt => opt.UseSqlite("Data Source=SqliteDatabase.db")
                );
            } else
            {
                services.AddDbContext<ErrorContext>(
                opt => opt.UseSqlite("Data Source=SqliteDatabase.db"));
            }

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200", 
                        "https://finalprojectwebsite-7c328.web.app",
                        "https://finalprojectwebsite-7c328.firebaseapp.com").AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<IProcessService, ProcessService>();
            services.AddScoped<IProcessRepository, ProcessRepository>();

            services.AddControllers();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<ErrorContext>();
                    DBSeeder.SeedDB(ctx);
                }
            } 
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<ErrorContext>();
                    DBSeeder.SeedDB(ctx);
                }
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

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
