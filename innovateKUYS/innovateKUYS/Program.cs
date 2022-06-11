using innovateKUYS.Models.Context;

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
            
        }
    }
}