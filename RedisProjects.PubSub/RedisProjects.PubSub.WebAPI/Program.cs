using RedisProjects.PubSub.Lib.Implementations;
using RedisProjects.PubSub.Lib.Implementations.Context;
using RedisProjects.PubSub.Lib.Interfaces;

namespace RedisProjects.PubSub.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddSingleton<IRedisContext, RedisContext>(x => new RedisContext("localhost:6380"));

            builder.Services.AddSingleton<IMessager, Messager>();



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
