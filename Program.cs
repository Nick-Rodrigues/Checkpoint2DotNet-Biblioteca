using Checkpoint2DotNet_Biblioteca.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint2_Biblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container de inje��o de dependencia. caixa ciclo de vida
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<FiapDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}