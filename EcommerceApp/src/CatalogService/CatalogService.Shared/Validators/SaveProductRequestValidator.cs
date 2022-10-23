using CatalogService.Shared.Commands;
using FluentValidation;

namespace CatalogService.Shared.Validators
{
    public class SaveProductRequestValidator: AbstractValidator<SaveProductCommandRequest>
    {
        public SaveProductRequestValidator()
        {
            RuleFor(p => p.Price).NotEmpty().WithMessage("Price Field Required");
            RuleFor(p => p.Name).MaximumLength(200).WithMessage("Name Field Max (200) Chars");
            RuleFor(p => p.Description).MaximumLength(40).WithMessage("Name Field Description (40) Chars");
            RuleFor(p => p.ImageFile).MaximumLength(50).WithMessage("ImageFile Field Max (200) Chars");
            RuleFor(p => p.Summary).MaximumLength(50).WithMessage("Summary Field Max (200) Chars");
            RuleFor(p => p.Category).MaximumLength(50).WithMessage("Category Field Max (200) Chars");
        }
    }
}
