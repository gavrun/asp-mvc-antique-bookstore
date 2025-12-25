using AntiqueBookstore.Data;
using AntiqueBookstore.Data.Interceptors;
using AntiqueBookstore.Data.Seed;
using AntiqueBookstore.Domain.Entities;
using AntiqueBookstore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AntiqueBookstore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // DI container configuration and Services

            var builder = WebApplication.CreateBuilder(args);

            // Logging configuration

            // builder.Logging.ClearProviders(); // remove default logging provider
            // builder.Logging.AddConsole();
            // builder.Logging.AddDebug(); // AddFile, AddSerilog
            // builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Debug); // Information, Warning, Error, Critical

            // Access HttpContext outside of Controllers/Middleware
            // registered by default AddControllersWithViews() or AddRazorPages()
            // builder.Services.AddHttpContextAccessor();

            // Interceptor configuration
            builder.Services.AddScoped<SalesAuditInterceptor>();

            // Connection configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }

            // Context configuration, ApplicationDbContext, SQL Server (mode Scoped) or PostgreSQL

            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            //    //options.UseNpgsql();

            // Context configuration, ApplicationDbContext using IServiceProvider
            builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                // Configure database provider
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging(); // WARNING: Sensitive data in logs

                // Configure resolved interceptor instance
                var interceptor = serviceProvider.GetRequiredService<SalesAuditInterceptor>();
                options.AddInterceptors(interceptor);
            });

            // Configure detailed error page for database-related exceptions
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            // Identity configuration, custom ApplicationUser, IdentityRole

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    //.AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    // Conifgure Identity options (Debug)
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI(); // ApplicationPartManager, IdentityOptions probably overriden here

            // Localization
            builder.Services.AddLocalization();

            // MVC configuration
            builder.Services
                .AddRazorPages()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            builder.Services
                .AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            // Services configuration
            builder.Services.AddScoped<IFileStorageService, LocalFileStorageService>();

            // Build application instance
            var app = builder.Build();

            // Seed user to Identity
            if (app.Environment.IsDevelopment())
            {
                await IdentitySeeder.SeedUserAsync(app);
            }

            // Middleware conveyor pipeline

            // Configure HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                // Debug
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // HTTP > HTTPS
            app.UseHttpsRedirection();
            // Static files, CSS, JS, images
            app.UseStaticFiles();

            app.UseRouting();

            // Request localization configuration
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("ru-RU")
            };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());

            app.UseRequestLocalization(localizationOptions);

            // Configure checks if user logged in and has permission to access resource
            app.UseAuthentication();
            app.UseAuthorization();

            // Endpoints

            // debug
            //app.MapGet("/ping", () => "pong");

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages(); 
            //    endpoints.MapControllers();
            //});

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Launch application on Kestrel
            app.Run();
        }
    }
}
