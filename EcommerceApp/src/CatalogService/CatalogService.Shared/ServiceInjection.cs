using CatalogService.Business.Services.Product;
using CatalogService.Infrastructure;
using CatalogService.Infrastructure.Repositories;
using CatalogService.Infrastructure.UoW;
using CatalogService.Shared.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Shared
{
    public static class ServiceInjection
    {
        public static void Inject(IServiceCollection services)
        {

            services.AddDbContext<CatalogContext>(options => options.UseSqlServer(""));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IProductService, ProductService>();
            services.AddMediatR(typeof(SaveProductCommandRequest));
        }
    }
}
