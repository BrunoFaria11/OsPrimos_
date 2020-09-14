using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Code;
using Ecommerce_MVC_Core.Data;
using Ecommerce_MVC_Core.Data.Seed;
using Ecommerce_MVC_Core.Models;
using Ecommerce_MVC_Core.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Ecommerce_MVC_Core
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyCon")));

            services.AddIdentity<ApplicationUsers, ApplicationRoles>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie"; // Name of cookie   
                     config.LoginPath = "/Users/Login"; // Path for the redirect to user login page  
                     config.AccessDeniedPath = "/Home/Error";
                 });

            services.AddAuthorization(config =>
            {
                var userAuthPolicyBuilder = new AuthorizationPolicyBuilder();
                config.DefaultPolicy = userAuthPolicyBuilder
                                    .RequireAuthenticatedUser()
                                    .RequireClaim(ClaimTypes.DateOfBirth)
                                    .Build();
            });

            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".HatBazar.Session";
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(20);
                options.Cookie.HttpOnly = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
       
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Users/Login";
                options.AccessDeniedPath = "/Home/Error";
                options.SlidingExpiration = true;
            });


            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireLowercase = false;

            //    //Lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //    options.Lockout.MaxFailedAccessAttempts = 10;

            //    //Cookie settings
            //    //options..ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
            //    //options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
            //    //options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";

            //    //user settings
            //    options.User.RequireUniqueEmail = true;


            //});

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.Expiration = TimeSpan.FromDays(150);
            //    options.LoginPath = "/Users/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
            //    options.LogoutPath = "/Users/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
            //    options.AccessDeniedPath = "/Users/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
            //    options.SlidingExpiration = true;
            //});

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<ApplicationUsers> userManager,
            RoleManager<ApplicationRoles> roleManager)
        {

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            IdentityDbInitializer.SeedData(userManager, roleManager);


            if (env.IsDevelopment())
            {
                app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
