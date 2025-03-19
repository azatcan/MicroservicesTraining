using CategoryService.Shared.Services;
using Duende.AccessTokenManagement;
using FluentValidation.AspNetCore;
using MicroService.WebApp.Extensions;
using MicroService.WebApp.Handler;
using MicroService.WebApp.Helpers;
using MicroService.WebApp.Models;
using MicroService.WebApp.Validators;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace MicroService.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
            builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAccessTokenManagement();
            builder.Services.AddSingleton<PhotoHelper>();
            builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

            builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            builder.Services.AddScoped<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClientServices(builder.Configuration);
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
            {
                opts.LoginPath = "/Auth/SignIn";
                opts.ExpireTimeSpan = TimeSpan.FromDays(60);
                opts.SlidingExpiration = true;
                opts.Cookie.Name = "udemywebcookie";
            });

            builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CourseCreateInputValidator>());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
