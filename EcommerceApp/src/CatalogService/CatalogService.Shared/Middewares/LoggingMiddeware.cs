using CatalogService.Business.Loggings;
using CatalogService.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
            var _loggingService = context.RequestServices.GetRequiredService<ILoggingService>();

            try
            {
                var requestBody = await ContextHelper.ReadRequestBody(context);
                await _loggingService.Log(Infrastructure.Enums.LogLevel.Info, requestBody);
                var responseBody = await ContextHelper.ReadResponseBody(context, _next);
                await _loggingService.Log(Infrastructure.Enums.LogLevel.Info, responseBody);
            }
            catch (Exception ex)
            {
                await _loggingService.Log(Infrastructure.Enums.LogLevel.Error, $"Error Message:{ex.Message}");
            }
        }
    }
}
