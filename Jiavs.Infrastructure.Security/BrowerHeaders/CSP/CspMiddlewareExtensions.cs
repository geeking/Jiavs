using Microsoft.AspNetCore.Builder;
using System;

namespace Jiavs.Infrastructure.Security.BrowerHeaders.CSP
{
    public static class CspMiddlewareExtensions
    {
        /// <summary>
        /// Add Content-Security-Policy header in ASP.NET Core to prevent XSS attacks
        /// https://tahirnaushad.com/2017/09/12/using-csp-header-in-asp-net-core-2-0/
        /// </summary>
        /// <param name="app"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCsp(
            this IApplicationBuilder app, Action<CspOptionsBuilder> builder)
        {
            var newBuilder = new CspOptionsBuilder();
            builder(newBuilder);

            var options = newBuilder.Build();
            return app.UseMiddleware<CspMiddleware>(options);
        }
    }
}