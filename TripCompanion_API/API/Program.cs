
using API.Middleware;
using BLL.Services;
using DAL.ApiRepos;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Tools.Connections;
using Tools.JWT;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Config Injection
            // - DB Connection

            builder.Services.AddTransient<Connection>((service) =>
            {
                return new Connection(
                    builder.Configuration.GetConnectionString("DBhome")
                );
            });

            // DAL
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ITripRepository, TripRepository>();
            builder.Services.AddTransient<IStepRepository, StepRepository>();
            builder.Services.AddTransient<ITodoRepository, TodoRepository>();

            // BLL // TODO: to make into IUserService etc ... ?
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<TripService>();
            builder.Services.AddTransient<StepService>();
            builder.Services.AddTransient<TodoService>();

            //JWT config
            JwtConfig config = builder.Configuration.GetSection("JwtToken").Get<JwtConfig>();
            builder.Services.AddSingleton(config);
            builder.Services.AddScoped<JwtSecurityTokenHandler>();
            builder.Services.AddScoped<JwtService>();

            //HTTPClient Factory
            //***
            builder.Services.AddHttpClient<GeoapifyAPI>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.geoapify.com/v1/geocode/");

            });
            //***
            builder.Services.AddHttpClient<OpenWeatherMapAPI>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");

            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<JwtMiddleware>(); 

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}