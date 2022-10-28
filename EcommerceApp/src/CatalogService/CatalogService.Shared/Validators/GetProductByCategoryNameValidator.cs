using CatalogService.Shared.Queries;
using FluentValidation;

namespace CatalogService.Shared.Validators
{
    public class GetProductByCategoryNameValidator: AbstractValidator<GetProductByCategoryQueryRequest>
    {
        public GetProductByCategoryNameValidator()
        {
            RuleFor(p => p.Category).NotEmpty()
                .MaximumLength(10)
                .WithMessage("Category Field Max (200) Chars");
        }
    }
}
