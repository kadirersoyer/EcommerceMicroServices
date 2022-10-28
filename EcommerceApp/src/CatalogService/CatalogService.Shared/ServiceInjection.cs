using CatalogService.Business.Loggings;
using CatalogService.Business.Services.Product;
using CatalogService.Infrastructure;
using CatalogService.Infrastructure.Repositories;
using CatalogService.Infrastructure.UoW;
using CatalogService.Shared.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Shared
{
    public static class ServiceInjection
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {

            var dataSource = configuration.GetConnectionString("Server");
            var database = configuration.GetConnectionString("Database");
            var userId = configuration.GetConnectionString("User");
            var password = configuration.GetConnectionString("Password");

            services.AddDbContext<CatalogContext>(options => options.UseSqlServer($"Data Source={dataSource};" +
                $" User Id={userId}; Initial Catalog={database}; Password={password}"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ILoggingService, LoggingService>();
            services.AddMediatR(typeof(SaveProductCommandRequest));
        }
    }
}
