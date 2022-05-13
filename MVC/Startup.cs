using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using MVC.Areas.Identity.Data;
using MVC.DAL;
using MVC.Data;

namespace MVC
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IHostelRepository, HostelRepository>();
            services.AddScoped<IPokojRepository, PokojRepository>();
            services.AddDbContext<HostelContext>(options =>
            {
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
                // options.UseInMemoryDatabase(databaseName:"hostels");
            });
            services.AddDbContext<MVCContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MVCContextConnection"));
            });
            services.AddIdentity<MVCUser, IdentityRole>()
                .AddEntityFrameworkStores<MVCContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "MyArea",
                    areaName: "SuperAdmin",
                    pattern: "SuperAdmin/{controller=UserRoles}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "MyArea",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Hostel}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "MyArea",
                    areaName: "Basic",
                    pattern: "Basic/{controller=View}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}