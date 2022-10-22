using CatalogService.Business.Loggings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace CatalogService.Shared.Middewares
{
    public class LoggingMiddeware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddeware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var loggingService = context.RequestServices.GetRequiredService<ILoggingService>();
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await loggingService.Log(Infrastructure.Enums.LogLevel.Error, $"Error Message:{ex.Message}");
            }
        }
    }
}
