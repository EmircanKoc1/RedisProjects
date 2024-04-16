using StackExchange.Redis;
using System.Data.SqlClient;

namespace RedisProject.AdvancedCache.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var m = ConnectionMultiplexer.Connect("localhost:6380");
            var db = m.GetDatabase();
            var key = new RedisKey("multikey");
            var value = new RedisValue("aldlMLþMLmlþmdnka");
            
            
       


            



            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
