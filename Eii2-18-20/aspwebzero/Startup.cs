using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aspwebzero
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Use(async (context, next) =>
            {
                Console.WriteLine("B (before)");
                await next.Invoke();
                Console.WriteLine("B (after)");
            });

            app.Use(async (context, next) =>
            {
                var path = context.Request.Path;
                Console.WriteLine(path);
                if (path == "/toto.html")
                {
                    Console.WriteLine("C'est toto");
                    Console.WriteLine("A (before)");
                    await next.Invoke();
                    Console.WriteLine("A (after)");
                }
                else if (path == "/pokemon/unite")
                {
                    await context.Response.WriteAsync("C'est un MOBA");
                }
                else
                {
                    Console.WriteLine("A (before)");
                    await next.Invoke();
                    Console.WriteLine("A (after)");
                }
            });

            app.UseLoggerC();
            app.UseStaticFiles();
            // Traiter le path de la requête et permettre à d'autres middleware de bénéficier du routage
            app.UseRouting();

            // Nécesssite d'appler useRouting avant
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/pokemon/go", async context =>
                {
                    await context.Response.WriteAsync("Attrapez les tous !!!!");
                });
                endpoints.MapGet("/viveasp/{name:alpha}", async context =>
                 {
                     var name = context.Request.RouteValues["name"];
                     await context.Response.WriteAsync($@"
                     <html>
                        <body>
                            viveasp {name}
                        </body>
                     </html>");
                 });

                endpoints.MapPost("/user/insert/{name:alpha}/{role:alpha}/{hp:int}", async context =>
                {
                    var name = context.Request.RouteValues["name"];
                    var role = context.Request.RouteValues["role"];
                    var hp = context.Request.RouteValues["hp"];
                    await context.Response.WriteAsync($"{name}, {role}, {hp}");
                });
            });
        }
    }

    static class Extension
    {
        public static void UseLoggerC(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine("C (before)");
                await next.Invoke();
                Console.WriteLine("C (after)");
            });
        }
    }
}
