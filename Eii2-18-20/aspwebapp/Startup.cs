using System;
using System.Linq;
using System.Security.Cryptography;
using aspfromscratch;
using efcore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aspwebapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<RandomNumberService>();
            services.AddDbContext<RpgContext>(options =>
            {
                Console.WriteLine(Configuration.GetSection("Toto")["Titi"]);
                var connectionString = Configuration.GetConnectionString("RpgContext");
                Console.WriteLine(connectionString);
                options.UseSqlite(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , RandomNumberService rns, RpgContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            Console.WriteLine(rns.GetNext());

            var powerfulSpells = context.MagicSpells.Where(ms => ms.Damage > 30);
            Console.WriteLine(string.Join(",", powerfulSpells));

            app.Use(async (context, next) =>
            {
                Console.WriteLine(rns.GetNext());
                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
