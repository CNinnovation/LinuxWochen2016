using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace LinuxWochenRC1VisualStudio.Middleware
{
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class HeadingMiddleware
    {
        private readonly RequestDelegate _next;

        public HeadingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("<h1>LinuxWochen</h1>");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HeadingMiddlewareExtensions
    {
        public static IApplicationBuilder UseHeadingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeadingMiddleware>();
        }
    }
}
