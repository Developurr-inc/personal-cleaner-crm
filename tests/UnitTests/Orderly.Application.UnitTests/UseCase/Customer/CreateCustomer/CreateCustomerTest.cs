using Moq;
using Orderly.Application.UnitTests.TestUtils.CreateCustomer;
using Orderly.Application.UseCase;
using Orderly.Application.UseCase.Customer.CreateCustomer;
using Orderly.Domain.Customer;
using Orderly.Domain.SalesConsultant;

namespace Orderly.Application.UnitTests.UseCase.Customer.CreateCustomer;

public class CreateCustomerTest
{
    [Fact]
    public void
        GivenValidInput_WhenInstantiatingCreateCustomerUseCase_ThenShouldInstantiateCreateCustomerUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();

        // Act
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);

        // Assert
        Assert.NotNull(createCustomerUseCase);
    }

    [Fact]
    public void
        GivenValidInput_WhenCallingExecute_ThenShouldReturnOutput()
    {
        // Arrange
        var createCustomerUseCase = CreateCustomerFixture.CreateUseCase();
        CreateCustomerInput input = null!;

        // Act
        var output = createCustomerUseCase.Execute(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }
}