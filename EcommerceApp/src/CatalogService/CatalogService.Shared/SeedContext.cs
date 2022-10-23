using CatalogService.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Shared
{
    public static class SeedContext
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<CatalogContext>();
                var databaseAvailable = context?.Database?.CanConnect() ?? false;

                if (!databaseAvailable)
                {
                    var connString = context?.Database.GetConnectionString();
                    context?.Database.Migrate();
                };

            }
        }
    }
}
