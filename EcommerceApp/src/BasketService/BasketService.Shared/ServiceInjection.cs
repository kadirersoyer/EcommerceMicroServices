using BasketService.Business.Services;
using BasketService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace BasketService.Shared
{
    public static class ServiceInjection
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            var redisConnectionString = configuration["Redis_ExternalIpAddress"];
            var redis = ConnectionMultiplexer.Connect(redisConnectionString);
            
            services.AddScoped(s => redis.GetDatabase());

            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService.Business.Services.BasketService>();
        }
    }
}
