

using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Tools.Connections;

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
            //string _connectionstring = builder.Configuration.GetConnectionString("DBbf");

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

            // BLL
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<TripService>();
            builder.Services.AddTransient<StepService>();
            builder.Services.AddTransient<TodoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}