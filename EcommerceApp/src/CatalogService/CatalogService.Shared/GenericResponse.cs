using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Shared
{
    public class GenericResponse<T> where T : class
    {
        public string? Message { get; set; }
        public T? Value { get; set; }
    }
}
