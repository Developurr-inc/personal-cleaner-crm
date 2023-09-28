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
    public async void
        GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = CreateCustomerFixture.CreateInput();
        
        // Act
        _ = await createCustomerUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void
        GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = CreateCustomerFixture.CreateInput();
        
        // Act
        _ = await createCustomerUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        customerRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Customer.Customer>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void
        GivenValidInput_WhenCallingExecute_ThenShouldCallGetByIdAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var customerRepositoryMock = new Mock<ICustomerRepository>();
        var salesConsultantRepositoryMock = new Mock<ISalesConsultantRepository>();
        var createCustomerUseCase = new CreateCustomerUseCase(unitOfWorkMock.Object, customerRepositoryMock.Object, salesConsultantRepositoryMock.Object);
        var input = CreateCustomerFixture.CreateInput();
        
        // Act
        _ = await createCustomerUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        salesConsultantRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<string>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async void
        GivenValidInput_WhenCallingExecute_ThenShouldReturnValidOutput()
    {
        // Arrange
        var createCustomerUseCase = CreateCustomerFixture.CreateUseCase();
        var input = CreateCustomerFixture.CreateInput();

        // Act
        var output = await createCustomerUseCase.Execute(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }
    
    [Fact]
    public async void
        GivenValidInput_WhenCallingExecute_ThenShouldReturnOutput()
    {
        // Arrange
        var createCustomerUseCase = CreateCustomerFixture.CreateUseCase();
        var input = CreateCustomerFixture.CreateInput();
        var expectedOutput = CreateCustomerFixture.CreateOutput();

        // Act
        var output = await createCustomerUseCase.Execute(input, CancellationToken.None);

        // Assert
        Assert.Equal(expectedOutput, output);
    }
}