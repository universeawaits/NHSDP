using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NHSDP_SPA.Core;
using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic.Implementation;
using NHSDP_SPA.Logic.Interface;
using System.Text;
using VironIT_Social_network_server.WEB.Identity;

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
            services.AddDbContext<IdentityContext>(
                options =>
                {
                    options.UseNpgsql(
                        Configuration.GetConnectionString("NHSDPConnection"),
                        builderConfig => builderConfig.MigrationsAssembly("NHSDP_SPA.WEB"));
                });
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;

                    options.User.RequireUniqueEmail = true;
                });
            services.AddCors();
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = JwtOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtOptions.Secret)),
                        ValidateIssuerSigningKey = true
                    };
                }
            );

            services.AddScoped<IUnitOfWork<InternshipContext>, UnitOfWork<InternshipContext>>();
            services.AddScoped(typeof(ICRUDServiceBase<>), typeof(CRUDServiceBase<>));
            services.AddScoped(provider => new MapperConfiguration(
                cfg => cfg.AddProfile(new WEBMapperProfile())).CreateMapper()
                );
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
        }
    }
}
