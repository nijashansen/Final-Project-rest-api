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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddDbContext<ErrorContext>(
                opt => opt.UseInMemoryDatabase("ErrorDatabase")
                );
            */

            services.AddDbContext<ErrorContext>(
                opt => opt.UseSqlite("Data Source=SqliteDatabase.db")
                );

            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<IErrorService, ErrorService>();

            services.AddControllers();
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
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
