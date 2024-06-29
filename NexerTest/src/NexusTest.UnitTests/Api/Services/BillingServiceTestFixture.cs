using NexerTest.Domain.Entities;

namespace NexerTest.UnitTests.Api.Services
{
    public class BillingServiceTestFixture : IDisposable
    {
        [CollectionDefinition(nameof(BillingServiceTestCollection))]
        public class BillingServiceTestCollection : ICollectionFixture<BillingServiceTestFixture> { }


        public IEnumerable<Customer?> CreateMultipleCustomers(int quantity)
        {
            var customers = new List<Customer?>();

            while (quantity != 0)
            {
                customers.Add(CreateCustomer());
                quantity--;
            }

            return customers;
        }

        public Customer? CreateCustomer()
        {
            return new Customer(Guid.NewGuid(), "Name", "Email", "Address");
        }

        public IEnumerable<Product?> CreateMultipleProducts(int quantity)
        {
            var products = new List<Product?>();

            while (quantity != 0)
            {
                products.Add(CreateProduct());
                quantity--;
            }

            return products;
        }

        public Product? CreateProduct()
        {
            return new Product(Guid.NewGuid(), "ProductA");
        }

        public void Dispose() { }
    }
}
