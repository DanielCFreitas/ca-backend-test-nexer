using Moq;
using NexerTest.Api.DTO.Request;
using NexerTest.Api.Services;
using NexerTest.Domain.Repositories;
using static NexerTest.UnitTests.Api.Services.BillingServiceTestFixture;

namespace NexerTest.UnitTests.Api.Services
{
    [Collection(nameof(BillingServiceTestCollection))]
    public class BillingServiceTest
    {
        private readonly BillingServiceTestFixture _billingServiceTestFixture;

        public BillingServiceTest(BillingServiceTestFixture billingServiceTestFixture)
        {
            _billingServiceTestFixture = billingServiceTestFixture;
        }

        [Fact]
        public async void BillingService_CreateBilling_ShouldCreateBillingWithSuccess()
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var billingRepositoryMock = new Mock<IBillingRepository>();

            customerRepositoryMock
                .Setup(repository => repository.SearchCustomerById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_billingServiceTestFixture.CreateCustomer()));

            productRepositoryMock
                .Setup(repository => repository.SearchProductById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_billingServiceTestFixture.CreateProduct()));

            billingRepositoryMock
                .Setup(repository => repository.unitOfWork.CommitAsync())
                .Returns(Task.CompletedTask);

            var billingService = new BillingService(productRepositoryMock.Object, customerRepositoryMock.Object, billingRepositoryMock.Object);

            var request = new AddBillingRequest("INV-01", DateTime.Now, DateTime.Now, "BRL", Guid.NewGuid(), Guid.NewGuid(), 1, .5m);

            // Act
            var resultado = await billingService.AddBilling(request);

            // Assert
            Assert.Equal(string.Empty, resultado.ErrorMessage);
        }

        [Fact]
        public async void BillingService_CreateBilling_ShouldRetornErrorCustomerNotFound()
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var billingRepositoryMock = new Mock<IBillingRepository>();

            customerRepositoryMock
                .Setup(repository => repository.SearchCustomerById(Guid.NewGuid()))
                .Returns(Task.FromResult(_billingServiceTestFixture.CreateCustomer()));

            productRepositoryMock
                .Setup(repository => repository.SearchProductById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_billingServiceTestFixture.CreateProduct()));

            billingRepositoryMock
                .Setup(repository => repository.unitOfWork.CommitAsync())
                .Returns(Task.CompletedTask);

            var billingService = new BillingService(productRepositoryMock.Object, customerRepositoryMock.Object, billingRepositoryMock.Object);

            var request = new AddBillingRequest("INV-01", DateTime.Now, DateTime.Now, "BRL", Guid.NewGuid(), Guid.NewGuid(), 1, .5m);

            // Act
            var resultado = await billingService.AddBilling(request);

            // Assert
            Assert.Equal("Customer not found", resultado.ErrorMessage);
        }

        [Fact]
        public async void BillingService_CreateBilling_ShouldRetornErrorProductNotFound()
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var billingRepositoryMock = new Mock<IBillingRepository>();

            customerRepositoryMock
                .Setup(repository => repository.SearchCustomerById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_billingServiceTestFixture.CreateCustomer()));

            productRepositoryMock
                .Setup(repository => repository.SearchProductById(Guid.NewGuid()))
                .Returns(Task.FromResult(_billingServiceTestFixture.CreateProduct()));

            billingRepositoryMock
                .Setup(repository => repository.unitOfWork.CommitAsync())
                .Returns(Task.CompletedTask);

            var billingService = new BillingService(productRepositoryMock.Object, customerRepositoryMock.Object, billingRepositoryMock.Object);

            var request = new AddBillingRequest("INV-01", DateTime.Now, DateTime.Now, "BRL", Guid.NewGuid(), Guid.NewGuid(), 1, .5m);

            // Act
            var resultado = await billingService.AddBilling(request);

            // Assert
            Assert.Equal("Product not found", resultado.ErrorMessage);
        }
    }
}
