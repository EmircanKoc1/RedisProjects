using Microsoft.Extensions.Configuration;
using RedisProjects.RedisService.CustomRedisService.Lib.Extensions;

namespace RedisProjects.RedisService.CustomRedisService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRedisService(builder.Configuration.GetConnectionString("Redis"));




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
