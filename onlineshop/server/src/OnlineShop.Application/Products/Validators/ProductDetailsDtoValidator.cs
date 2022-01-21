using FluentValidation;
using OnlineShop.Application.Products.Common;

namespace OnlineShop.Application.Products.Validators;

internal class ProductDetailsDtoValidator : AbstractValidator<ProductDetailsDto>
{
    public ProductDetailsDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Description)
            .MaximumLength(400)
            .NotEmpty();

        RuleFor(x => x.Price)
            .InclusiveBetween(0, 1_000_000);
    }
}