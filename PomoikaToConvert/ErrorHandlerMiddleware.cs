using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PomoikaToConvert
{
    public class ErrorHandlerMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("Access Denied");
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("This page does not exist");
            }
            else if (context.Response.StatusCode == 500)
            {
                await context.Response.WriteAsync("Developer is a intellectual beggar");
            }
        }
    }
}