using FluentValidation;
using InvoiceApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Validators
{
    public class AddInvoiceValidator : AbstractValidator<AddInvoiceModel>
    {
        public AddInvoiceValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name should be defined.")
                .Length(0,32)
                .WithMessage("Customer name should have 32 charathers at most.");
            RuleFor(x => x.InvoicePayday)
                .NotEmpty()
                .WithMessage("Payday date should be defined.")
                .GreaterThan(x => DateTime.Now)
                .WithMessage("Payday date should be greater then current date.");
            RuleFor(x => x.Tax)
                .NotEmpty()
                .WithMessage("VAT should be defined.");
            RuleFor(x => x.ProductQuantitys)
                .NotEmpty()
                .WithMessage("At least one product should be defined.");
        }
    }
}