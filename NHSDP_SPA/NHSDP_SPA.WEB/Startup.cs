using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NHSDP_SPA.Core;
using NHSDP_SPA.Logic.Implementation;
using NHSDP_SPA.Logic.Interface;


namespace NHSDP_SPA.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InternshipContext>(
                options =>
                {
                    options.UseNpgsql(
                        Configuration.GetConnectionString("NHSDPConnection"),
                        builderConfig => builderConfig.MigrationsAssembly("NHSDP_SPA.WEB"));
                });

            services.AddScoped<IUnitOfWork<InternshipContext>, UnitOfWork<InternshipContext>>();
            services.AddScoped(typeof(ICRUDServiceBase<>), typeof(CRUDServiceBase<>));
            services.AddScoped(provider => new MapperConfiguration(
                cfg => cfg.AddProfile(new WEBMapperProfile())).CreateMapper()
                );

            services.AddCors();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                if (context.Response.StatusCode != StatusCodes.Status401Unauthorized)
                {
                    await next.Invoke();
                }
            });
            app.UseRouting();
        }
    }
}
