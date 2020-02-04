using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NHSDP_Request_handling.Core;
using NHSDP_Request_handling.WEB.Service;
using NHSDP_Request_handling.WEB.Service.Implementation;
using NHSDP_Request_handling.WEB.Service.Interface;


namespace NHSDP_Request_handling.WEB
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Office}/{action=Index}/{id?}");
            });
        }
    }
}
