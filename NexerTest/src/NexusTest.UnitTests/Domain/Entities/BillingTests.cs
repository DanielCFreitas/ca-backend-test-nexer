using NexerTest.Domain.Entities;

namespace NexerTest.UnitTests.Domain.Entities
{
    public class BillingTests
    {
        [Fact(DisplayName = "Calcule total amount")]
        [Trait("Billing", "Billing Tests")]
        public void Billing_ShouldCalculeTotalAmount()
        {
            // Arrange
            var random = new Random();
            var customer = new Customer(Guid.NewGuid(), "Daniel", "daniel@gmail.com", "Avenida Brasil");
            var products = new List<Product>()
            {
                new Product(Guid.NewGuid(), "Product A"),
                new Product(Guid.NewGuid(), "Product B"),
                new Product(Guid.NewGuid(), "Product C")
            };
            var billingLines = new List<BillingLine>()
            {
                new BillingLine(Guid.NewGuid(), products[0].Id, products[0].Name, random.Next(0, 10), Math.Round((decimal) random.NextDouble(), 2)),
                new BillingLine(Guid.NewGuid(), products[1].Id, products[1].Name, random.Next(0, 10), Math.Round((decimal) random.NextDouble(), 2)),
                new BillingLine(Guid.NewGuid(), products[2].Id, products[2].Name, random.Next(0, 10), Math.Round((decimal) random.NextDouble(), 2))
            };

            var billing = new Billing(Guid.NewGuid(), "INV-001", customer, DateTime.Now, DateTime.Now, "BRL");
            foreach (var billingLine in billingLines)
                billing.AddBillingLine(billingLine);

            // Act
            var totalAmount = billing.TotalAmount();
            var totalCalculated = billingLines.Sum(billingLine => billingLine.Quantity * billingLine.UnitPrice);

            // Assert
            Assert.Equal(totalAmount, totalCalculated);
        }
    }
}
