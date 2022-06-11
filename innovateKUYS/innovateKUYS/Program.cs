using innovateKUYS.Business.StudentBs;
using innovateKUYS.Controllers;
using innovateKUYS.Models.Context;
using innovateKUYS.Models.ViewsModels;

namespace innovateKUYS
{
    public class Program
    {
        private IConfiguration configuration;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            AppSettings appSettings=  builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
            DatabaseInitializer databaseInitializer = new DatabaseInitializer(new DatabaseContext(),appSettings);
            databaseInitializer.Seed();

           
            //builder.Services.AddDbContext<DatabaseContext>();
            builder.Services.AddSingleton<StudentService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}");

            app.Run();
            
        }
    }
}