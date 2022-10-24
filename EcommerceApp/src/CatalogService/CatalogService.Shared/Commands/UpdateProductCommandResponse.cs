using CatalogService.Shared.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Shared.Commands
{
    public class UpdateProductCommandResponse
    {
        public ProductModel? ProductModel{ get; set; }
    }
}
