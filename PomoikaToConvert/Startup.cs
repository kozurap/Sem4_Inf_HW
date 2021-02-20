using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PomoikaToConvert
{
    public class Startup
    {
        public void ConfigureServises(IServiceCollection service)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("aaaaaaaaaaaaaaaaaA");
                await next();
                await context.Response.WriteAsync("\nbbbbbbbbbbbbbbbbbB");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\naaaaaaaaaaaaaaaaAA");
                await next();
                await context.Response.WriteAsync("\nbbbbbbbbbbbbbbbbBB");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\naaaaaaaaaaaaaaaAAA");
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/George",
                    async context =>
                    {
                        await context.Response.WriteAsync
                            ("Hi my name is " + env.EnvironmentName + " I am from Chilladelphia");
                    });
            });
        }
    }
}