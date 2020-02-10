using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NHSDP_Request_handling.Core;
using NHSDP_Request_handling.Logic.Implementation;
using NHSDP_Request_handling.Logic.Interface;
using NHSDP_Request_handling.WEB.Logging;
using System;

namespace NHSDP_Request_handling.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            FileLogger = new FileLogger { FilePath = Configuration.GetSection("Logging").GetValue<string>("FilePath") };
            ConsoleLogger = new ConsoleLogger();
        }

        public IConfiguration Configuration { get; }
        public ILogger FileLogger { get; set; }
        public ILogger ConsoleLogger { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<InternshipContext>(
                options =>
                {
                    options.UseNpgsql(
                        Configuration.GetConnectionString("NHSDPConnection"),
                        builderConfig => builderConfig.MigrationsAssembly("NHSDP_Request_handling.WEB"));
                });

            services.AddScoped<IUnitOfWork<InternshipContext>, UnitOfWork<InternshipContext>>();
            services.AddScoped(typeof(ICRUDServiceBase<>), typeof(CRUDServiceBase<>));
            services.AddScoped(provider => new MapperConfiguration(
                cfg => cfg.AddProfile(new WEBMapperProfile())).CreateMapper()
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                ConsoleLogger.Log("[" + DateTime.Now + "] " + context.Request.Method + " " + context.Request.Path);
                FileLogger.Log("[" + DateTime.Now + "] " + context.Request.Method + " " + context.Response.StatusCode + " " + context.Response.ContentType + " " + context.Request.Path);

                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Internship}/{action=Index}/{id?}");
            });
        }
    }
}
