using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jiavs.Infrastructure.Repository.Context;
using Jiavs.Infrastructure.Security.BrowerHeaders.CSP;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Jiavs.MVC.Settings;
using Microsoft.Extensions.Options;
using Jiavs.Infrastructure.Identity.Extensions;
using Jiavs.Infrastructure.Identity.Data;
using Jiavs.Application.IServices;
using Jiavs.Application.Services;
using Jiavs.Application.Extensions;

namespace Jiavs.MVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddApplicationInjection();

            var mysqlConStr = Configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<JiavsContext>(options =>
            {
                options.UseMySql(mysqlConStr);
            });

            services.AddDbContext<UserContext>(options =>
            {
                options.UseMySql(mysqlConStr);
            });

            services.AddCustomIdentity();

            //自定义URL格式为小写，多单词间用“-”分割
            services.AddRouting(options =>
            {
                options.ConstraintMap["HyphenRoute"] = typeof(HyphenRouteTransformer);
                options.LowercaseUrls = true;
            });

            services.AddMvc(options =>
            {
                //全局添加防跨站请求伪造
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // Add Content-Security-Policy header in ASP.NET Core to prevent XSS attacks
            app.UseCsp(builder =>
            {
                builder.Defaults
                       .AllowSelf();

                builder.Scripts
                       .AllowSelf();

                builder.Styles
                       .AllowSelf();

                builder.Fonts
                       .AllowSelf();

                builder.Images
                       .AllowSelf();
            });
            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller:HyphenRoute=Home}/{action:HyphenRoute=Index}/{id?}");
            });
        }
    }
}