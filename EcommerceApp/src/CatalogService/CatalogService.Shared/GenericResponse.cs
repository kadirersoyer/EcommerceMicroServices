using FluentValidation.Results;

namespace CatalogService.Shared
{
    public class GenericResponse<T> where T : class, new()
    {
        public ValidationResult? ValidationResult { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string? Message { get; set; }
        public T? Value { get; set; }
    }
}
