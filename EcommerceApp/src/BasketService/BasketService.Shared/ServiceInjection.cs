using BasketService.Business.Services;
using BasketService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BasketService.Shared
{
    public static class ServiceInjection
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            var redisConnectionString = configuration["CacheSettings:ConnectionString"];

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = redisConnectionString;
            });

            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService.Business.Services.BasketService>();
        }
    }
}
