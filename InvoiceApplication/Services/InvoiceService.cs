using InvoiceApplication.Interfaces.Modules;
using InvoiceApplication.Interfaces.RepositoryInterfaces;
using InvoiceApplication.Interfaces.Services;
using InvoiceApplication.Models.Data;
using InvoiceApplication.Validators;
using InvoiceApplication.ViewModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InvoiceApplication.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExtensionModule _extensions;

        public InvoiceService(IUnitOfWork unitOfWork, IExtensionModule extension)
        {
            _unitOfWork = unitOfWork;
            _extensions = extension;
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _unitOfWork.InvoiceRepository.Get();
        }

        public Invoice GetByIdInvoice(int id)
        {
            return _unitOfWork.InvoiceRepository.GetByID(id);
        }

        public Invoice CreateInvoice(AddInvoiceModel addInvoiceModel, string user)
        {
            Invoice lastInvoice = _unitOfWork.InvoiceRepository.Get().LastOrDefault();

            ICollection<InvoiceProduct> invoiceProducts = GenerateInvoiceProducts(addInvoiceModel.ProductQuantitys);

            decimal totalTaxFree = invoiceProducts.Sum(x => x.TotalPriceTaxFree);

            string taxName = _unitOfWork.InvoiceTaxRepository.GetByID(addInvoiceModel.Tax).TaxName;

            Invoice newInvoice = new Invoice()
            {
                InvoiceNumber = lastInvoice != null ? lastInvoice.InvoiceNumber + 1 : 0,
                InvoiceCreated = DateTime.Now,
                InvoicePayday = addInvoiceModel.InvoicePayday,
                InvoiceProducts = invoiceProducts,
                TotalTaxFree = totalTaxFree,
                TotalTax = _extensions.GetExtension<ITaxCalculator>(taxName).CalculateTax(totalTaxFree),
                CustomerName = addInvoiceModel.CustomerName,
                InvoiceCreator =user,
                InvoiceTaxId = addInvoiceModel.Tax
            };
            return newInvoice;
        }

        private ICollection<InvoiceProduct> GenerateInvoiceProducts(IEnumerable<ProductQuantityModel> productQuantities)
        {
            var invoiceProducts = new List<InvoiceProduct>();
            var deduplicatedProductQuantities = productQuantities.GroupBy(x => x.ProductId).Select(x => new ProductQuantityModel()
            {
                ProductId = x.Key,
                Quantity = x.Sum(c => c.Quantity)
            });

            foreach (var productQuantity in deduplicatedProductQuantities)
            {

                var product = _unitOfWork.ProductRepository.GetByID(productQuantity.ProductId);
                invoiceProducts.Add(new InvoiceProduct()
                {
                    SellCount = productQuantity.Quantity,
                    PriceTaxFree = product.Price,
                    TotalPriceTaxFree = product.Price * productQuantity.Quantity,
                    ProductId = productQuantity.ProductId
                });
            }

            return invoiceProducts;
        }

        public void AddInvoice(Invoice invoice)
        {
            _unitOfWork.InvoiceRepository.Insert(invoice);
            _unitOfWork.Save();
        }

        public void DeleteInvoice(int id)
        {
            Invoice invoice = _unitOfWork.InvoiceRepository.GetByID(id);
            _unitOfWork.InvoiceRepository.Delete(invoice);
            _unitOfWork.Save();
        }

        public IEnumerable<ErrorResponse> GetAllValidationErrors(AddInvoiceModel addInvoiceModel)
        {
            var validationResults = new AddInvoiceValidator().Validate(addInvoiceModel);
            var response = new List<ErrorResponse>();
            foreach (var failure in validationResults.Errors)
            {
                var errorResponse = new ErrorResponse(failure.ErrorCode, failure.ErrorMessage);
                response.Add(errorResponse);
                _logger.Error(errorResponse.ToString());
            }
            return response;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.ProductRepository.Get();
        }

        public IEnumerable<InvoiceTax> GetAllTaxes()
        {
            return _unitOfWork.InvoiceTaxRepository.Get();
        }
    }
}