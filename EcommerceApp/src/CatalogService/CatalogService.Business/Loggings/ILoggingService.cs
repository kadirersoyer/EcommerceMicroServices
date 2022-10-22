using CatalogService.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.Loggings
{
    public interface ILoggingService
    {
        Task Log(LogLevel logLevel, string message);   
    }
}
