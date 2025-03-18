using FluentValidation;
using ProductManagement.Api.Models;

namespace ProductManagement.Api.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required").Length(3, 50).WithMessage("Name must be between 3 and 50 characters");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").MaximumLength(300).WithMessage("Description must be less than 300 characters");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock must be 0 or greater");
    }
}