using NexerTest.Api.DTO.Request;
using NexerTest.Api.DTO.Response;
using NexerTest.Api.Services.Interfaces;
using NexerTest.Domain.Entities;
using NexerTest.Domain.Repositories;
using NexerTest.SharedKernel.Api;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.Api.Services
{
    public class BillingService : BaseService, IBillingService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBillingRepository _billingRepository;

        public BillingService(IProductRepository productRepository, ICustomerRepository customerRepository, IBillingRepository billingRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _billingRepository = billingRepository;
        }

        public async Task<ValidationResult> AddBilling(AddBillingRequest request)
        {
            var customer = await _customerRepository.SearchCustomerById(request.CustomerId);
            if (customer is null)
                return new ValidationResult("Customer not found");

            var product = await _productRepository.SearchProductById(request.ProductId);
            if (product is null)
                return new ValidationResult("Product not found");

            var billing = new Billing(Guid.NewGuid(), request.InvoiceNumber, customer, request.Date, request.DueDate, request.Currency);
            var billingLine = new BillingLine(Guid.NewGuid(), product.Id, product.Name, request.Quantity, request.UnitPrice);
            billing.AddBillingLine(billingLine);

            _billingRepository.AddBilling(billing);
            await SaveChanges(_billingRepository.unitOfWork);
            return new ValidationResult("");
        }

        public async Task<IEnumerable<BillingResponse>> BillingsList()
        {
            var billings = await _billingRepository.ListBillings();

            return billings.Select(cobranca =>
            {
                var customer = new CustomerResponse(cobranca.Customer.Id, cobranca.Customer.Name, cobranca.Customer.Email, cobranca.Customer.Name);

                var billingLines = cobranca.BillingLines.Select(billinLine => new BillingLineResponse(billinLine.ProductId, billinLine.Description));

                return new BillingResponse(
                    cobranca.Currency,
                    cobranca.Date,
                    cobranca.DueDate,
                    cobranca.TotalAmount(),
                    cobranca.Currency,
                    customer,
                    billingLines);
            });
        }
    }
}
