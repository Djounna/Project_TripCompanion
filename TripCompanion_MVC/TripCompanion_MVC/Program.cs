using System.Net.Http.Headers;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Services;
using TripCompanion_MVC.Services.ApiExternal;

namespace TripCompanion_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // ** Add Sessions services 
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            // ** Add ContexteAccessor services & SessionManager DI
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<SessionManager>();

            // *** DependancyInjection
            // Services
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ITripService, TripService>();
            builder.Services.AddTransient<IStepService, StepService>();
            builder.Services.AddTransient<ITodoService, TodoService>();
            

            // CLient Factory WIth Base Address configuration => Used as AddTransient (Source: MSDN)
            /* A HttpClient service can now be called in the constructor of the service => It will create a new HttpClient. It is equivalent to HttpClientFactory.CreateClient() method */
            builder.Services.AddHttpClient<IApiConsume, ApiConsume>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:7195/api/");
                
            });
            //***
            builder.Services.AddHttpClient<NominatimAPI>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://nominatim.openstreetmap.org/");

            });
            //***
            builder.Services.AddHttpClient<GeoapifyAPI>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.geoapify.com/v1/geocode/");

            });



            /*********************************************************************************************************************************************/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // *** Middleware Session
            app.UseSession();

            // Classic Middlewares
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