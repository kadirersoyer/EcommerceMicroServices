using CatalogService.Infrastructure.Enums;

namespace CatalogService.Business.Loggings
{
    public class LoggingService : ILoggingService
    {
        public Task Log(LogLevel logLevel, string message)
        {
            // log
            return Task.CompletedTask;
        }
    }
}
