using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Services;

namespace TripCompanion_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //CLient Factory WIth Base Address configuration => Used as AddTransient (Source: MSDN)
            /* A HttpClient service can now be called in the constructor of the service => It will create a new HttpClient. It is equivalent to HttpClientFactory.CreateClient() method */
            builder.Services.AddHttpClient<IApiConsume, ApiConsume>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:7195/api/");

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