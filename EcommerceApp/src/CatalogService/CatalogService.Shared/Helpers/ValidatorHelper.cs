using CatalogService.Shared.Commands;
using CatalogService.Shared.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace CatalogService.Shared.Helpers
{
    public static class ValidatorHelper
    {
        /// <summary>
        ///  Add Every Validator Goes Here by adding new line
        /// </summary>
        private static readonly Dictionary<Type, Type> validators = new Dictionary<Type, Type>()
        {
            { typeof(SaveProductCommandRequest),typeof(SaveProductRequestValidator) },
            { typeof(UpdateProductCommandRequest),typeof(UpdateProductRequestValidator) }
        };

        /// <summary>
        ///  Genericr Validator Magic From Kadir :)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validatableData"></param>
        /// <returns></returns>
        public static async Task<ValidationResult> ValidateAsync<T>(T validatableData) where T : class
        {
            var type = typeof(T);
            var validatorType = validators[type];
            var instance = Activator.CreateInstance(validatorType);
            if (instance != null)
            {
                var validator = (AbstractValidator<T>)instance;
                return await validator.ValidateAsync(validatableData);
            }
            return await Task.FromResult(new ValidationResult());
        }

    }
}
