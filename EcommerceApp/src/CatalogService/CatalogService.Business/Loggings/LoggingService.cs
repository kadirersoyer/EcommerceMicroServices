using CatalogService.Infrastructure.Enums;
using Microsoft.Extensions.Hosting;

namespace CatalogService.Business.Loggings
{
    public class LoggingService : ILoggingService
    {
        private readonly IHostEnvironment _hostEnvironment;

        public LoggingService(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async Task Log(LogLevel logLevel, string message)
        {
            var folderPath = Path.Combine(_hostEnvironment.ContentRootPath, "Logs");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Path.Combine(folderPath, $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.txt");
            await File.AppendAllTextAsync(fileName, message);
        }
    }
}
