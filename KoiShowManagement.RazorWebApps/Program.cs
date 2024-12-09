using KoiShowManagement.Repositories;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Service;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service;

namespace KoiShowManagement.RazorWebApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure cookie
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
             {
             options.LoginPath = "/Account/Login";
             options.AccessDeniedPath = "/Account/AccessDenied";
             options.Cookie.Name = "KoiShowAuth";
             options.Cookie.HttpOnly = true;
             options.ExpireTimeSpan = TimeSpan.FromHours(1);
             options.SlidingExpiration = true;
             });

            builder.Services.AddAuthorization();

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AllowAnonymousToPage("/Account/Login");
                options.Conventions.AllowAnonymousToPage("/Account/AccessDenied");
            });

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<RegistrationService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<RoleService>();
            builder.Services.AddScoped<CompetitionService>();
            builder.Services.AddScoped<CompetitionTypeService>();
            builder.Services.AddScoped<AnimalService>();
            builder.Services.AddScoped<AnimalVarietyService>();
            builder.Services.AddScoped<CompetitionCategoryService>();
            builder.Services.AddSession();
            builder.Services.AddScoped<IScoreService, ScoreService>();
            builder.Services.AddHostedService<ScoreWorker>();
            builder.Services.AddScoped<PointOnProgressingService>();
            builder.Services.AddSignalR();
            builder.Services.AddScoped<FinalResultService>();
            builder.Services.AddScoped<UserRepository>();
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/Login";
            //        options.AccessDeniedPath = "/Error";
            //    });

            builder.Services.AddDbContext<FA24_PRN221_3W_G6_KoiShowManagementContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogInformation($"Request path: {context.Request.Path}");
                logger.LogInformation($"User authenticated: {context.User.Identity.IsAuthenticated}");
                
                await next();
            });

            app.MapRazorPages();
            app.MapHub<NotificationHub>("/notificationHub");
            app.Run();
        }
    }
}
