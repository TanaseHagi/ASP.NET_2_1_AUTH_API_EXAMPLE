using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_2_1_AUTH_API_EXAMPLE.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace ASP.NET_2_1_AUTH_API_EXAMPLE
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
            // services.Configure<CookiePolicyOptions>(options =>
            // {
            //     // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //     options.CheckConsentNeeded = context => true;
            //     options.MinimumSameSitePolicy = SameSiteMode.None;
            // });

            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            // services.AddDbContext<ToDoItemContext>(opt =>
            //     opt.UseInMemoryDatabase("TodoList"));

            services.AddDbContext<ToDoItemContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("ToDoItemConnection")));

            services.AddDbContext<ToDoUserContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("ToDoUserConnection")));

            // services.AddDefaultIdentity<IdentityUser>()
            //     .AddEntityFrameworkStores<ToDoUserContext>();

            // services.AddIdentity<ToDoUser, IdentityRole>()
            //     .AddEntityFrameworkStores<ToDoUserContext>()
            //     .AddDefaultTokenProviders();

            // services.Configure<IdentityOptions>(options =>
            // {
            //     // Password settings
            //     options.Password.RequireDigit = true;
            //     options.Password.RequiredLength = 8;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireUppercase = true;
            //     options.Password.RequireLowercase = false;
            //     options.Password.RequiredUniqueChars = 6;

            //     // Lockout settings
            //     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //     options.Lockout.MaxFailedAccessAttempts = 10;
            //     options.Lockout.AllowedForNewUsers = true;

            //     // User settings
            //     options.User.RequireUniqueEmail = true;
            // });

            // services.ConfigureApplicationCookie(options =>
            // {
            //     // Cookie settings
            //     options.Cookie.HttpOnly = true;
            //     options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //     // If the LoginPath isn't set, ASP.NET Core defaults 
            //     // the path to /Account/Login.
            //     options.LoginPath = "/Account/Login";
            //     // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
            //     // the path to /Account/AccessDenied.
            //     options.AccessDeniedPath = "/Account/AccessDenied";
            //     options.SlidingExpiration = true;
            // });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {


            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );

            app.UseMvc();
        }
    }
}
