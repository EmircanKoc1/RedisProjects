
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisProjects.RedisService.CustomRedisService.Lib.Context;
using RedisProjects.RedisService.CustomRedisService.Lib.Abstractions;
using services = RedisProjects.RedisService.CustomRedisService.Lib.Implementations;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Extensions;

public static class RedisExtensions
{

 
    public static IServiceCollection AddRedisService(this IServiceCollection services, string connectionString)
    {


        services.AddSingleton(x => new RedisContext(connectionString));

        services.AddScoped<IRedisService, services.RedisService>();

        return services;
    }


}
