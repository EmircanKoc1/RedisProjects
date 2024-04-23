using RedisProjects.RedisService.CustomRedisService.Context;
using RedisProjects.RedisService.CustomRedisService.Services;
using services = RedisProjects.RedisService.CustomRedisService.Services;
using StackExchange.Redis;

namespace RedisProjects.RedisService.CustomRedisService
{
    public class Program
    {
        public static void Main(string[] args)
        {



            var builder = WebApplication.CreateBuilder(args);
            

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton(x => new RedisContext(builder.Configuration.GetConnectionString("Redis")));

            builder.Services.AddScoped<IRedisService, services.RedisService>();

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
