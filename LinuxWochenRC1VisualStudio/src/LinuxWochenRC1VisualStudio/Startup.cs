using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using LinuxWochenRC1VisualStudio.Controllers;
using LinuxWochenRC1VisualStudio.Services;
using LinuxWochenRC1VisualStudio.Middleware;

namespace LinuxWochenRC1VisualStudio
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWeekdayService, WeekdayService>();
            services.AddTransient<SaturdayController>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseHeadingMiddleware();

            app.UseMvcWithDefaultRoute();

            app.Map("/Weekday", builder =>
            {
                builder.Run(async context =>
                {
                    var service = context.RequestServices.GetService<IWeekdayService>();
                    await context.Response.WriteAsync(
                        $"<h2>{service.GetDay()}</h2>");
                });
            });

            app.MapWhen(context => context.Request.Path.Value.Contains("Linux"), 
                builder =>
            {
                builder.Run(async context =>
                {
                    await context.Response.WriteAsync("<h2>In the Linux route</h2>");
                });
            });

            app.Map("/About", builder =>
            {
                builder.Run(async context =>
                {
                    await context.Response.WriteAsync("<h2>About LinuxWochen</h2>");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h2>Hello World!</h2>");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
