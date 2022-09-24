using FluentValidation;
using InvoiceApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.Validators
{
    public class FluentValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static FluentValidatorFactory()
        {
            validators.Add(typeof(IValidator<AddInvoiceModel>), new AddInvoiceValidator());
            validators.Add(typeof(IValidator<ProductQuantityModel>), new ProductQuantityValidator());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}