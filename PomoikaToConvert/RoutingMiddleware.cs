using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PomoikaToConvert
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/index")
            {
                Console.WriteLine(context.Request.Body);
                await context.Response.WriteAsync("Home Page");
            }
            else if (path == "/about")
            {
                Console.WriteLine(context.Request.Body);
                await context.Response.WriteAsync("About");
            }
            else if (path == "/404")
            {
                Console.WriteLine(context.Request.Body);
                context.Response.StatusCode = 404;
            }
            else if (path == "/500")
            {
                Console.WriteLine(context.Request.Body);
                context.Response.StatusCode = 500;
            }
            else if (path == "/admin")
            {
                Console.WriteLine(context.Request.Body);
                context.Response.StatusCode = 403;
            }
            else
            {
                Console.WriteLine(context.Request.Body);
                context.Response.StatusCode = 500;
            }
        }
    }
}