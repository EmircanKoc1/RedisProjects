using RedisProjects.RedisClient.CustomRedisClient.Context;
using RedisProjects.RedisClient.CustomRedisClient.Services;
using StackExchange.Redis;

namespace RedisProjects.RedisClient.CustomRedisClient
{
    public class Program
    {
        public static void Main(string[] args)
        {

          

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<RedisContext>(x => new RedisContext(builder.Configuration.GetConnectionString("Redis")));

            builder.Services.AddScoped<IRedisService, RedisService>();

            //builder.Services.AddScoped<RedisService>(x=> new RedisService(new RedisContext(builder.Configuration.GetConnectionString("Redis"))));

            var app = builder.Build();

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
