using CatalogService.Shared.Models.Product;
using FluentValidation.Results;

namespace CatalogService.Shared.Commands
{
    public class SaveProductCommandResponse
    {
        public ProductModel? ProductModel { get; set; }
        public ValidationResult? ValidationResult { get; set; }
    }
}
