using FluentValidation;
using InvoiceApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Validators
{
    public class ProductQuantityValidator : AbstractValidator<ProductQuantityModel>
    {
        public ProductQuantityValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product id should be defined.");
            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Product quantity should be defined.")
                .GreaterThanOrEqualTo(1)
                .WithMessage("At least one product should be defined.");
        }
    }
}