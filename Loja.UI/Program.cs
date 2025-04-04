using Loja.UI.Data;
using Microsoft.AspNetCore.Identity;
using Loja.UI.Configurations;
using Loja.UI.Components;
using Loja.Data.Repositories;
using Loja.Data.Repositories.Interfaces;


namespace Loja.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            builder.AddDatabaseSelector();


            // Add services to the container.

            builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.UseDbMigrationHelper();

            app.UseStaticFiles();

            app.Run();
        }
    }
}
