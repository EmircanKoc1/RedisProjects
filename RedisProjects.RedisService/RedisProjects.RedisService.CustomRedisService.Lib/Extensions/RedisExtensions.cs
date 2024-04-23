
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisProjects.RedisService.CustomRedisService.Context;
using RedisProjects.RedisService.CustomRedisService.Services;
using services = RedisProjects.RedisService.CustomRedisService.Services;

namespace RedisProjects.RedisService.CustomRedisService.Extensions
{
    public static class RedisExtensions
    {

     
        public static IServiceCollection AddRedisService(this IServiceCollection services, string connectionString)
        {


            services.AddSingleton(x => new RedisContext(connectionString));

            services.AddScoped<IRedisService, services.RedisService>();

            return services;
        }


    }



}
