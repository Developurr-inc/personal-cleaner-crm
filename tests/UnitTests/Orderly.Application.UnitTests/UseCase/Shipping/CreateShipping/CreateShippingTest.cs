using Moq;
using Orderly.Application.UnitTests.TestUtils.CreateShipping;
using Orderly.Application.UseCase;
using Orderly.Application.UseCase.Shipping.CreateShipping;
using Orderly.Domain.Exceptions;
using Orderly.Domain.Shipping;

namespace Orderly.Application.UnitTests.UseCase.CreateShipping;

public class CreateShippingTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingCreateShippingUseCase_ThenShouldInstantiateCreateShippingUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var shippingRepositoryMock = new Mock<IShippingRepository>();

        // Act
        var createShippingUseCase = new CreateShippingUseCase(unitOfWorkMock.Object, shippingRepositoryMock.Object);

        // Assert
        Assert.NotNull(createShippingUseCase);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var shippingRepositoryMock = new Mock<IShippingRepository>();
        var createShippingUseCase = new CreateShippingUseCase(unitOfWorkMock.Object, shippingRepositoryMock.Object);
        var input = CreateShippingFixture.CreateInput();
        
        // Act
        _ = await createShippingUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        shippingRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Shipping.Shipping>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var shippingRepositoryMock = new Mock<IShippingRepository>();
        var createShippingUseCase = new CreateShippingUseCase(unitOfWorkMock.Object, shippingRepositoryMock.Object);
        var input = CreateShippingFixture.CreateInput();
        
        // Act
        _ = await createShippingUseCase.Execute(input, CancellationToken.None);
        
        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnValidOutput()
    {
        // Arrange
        var createShippingUseCase = CreateShippingFixture.CreateUseCase();
        var input = CreateShippingFixture.CreateInput();

        // Act
        var output = await createShippingUseCase.Execute(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnOutput()
    {
        // Arrange
        var createShippingUseCase = CreateShippingFixture.CreateUseCase();
        var input = CreateShippingFixture.CreateInput();

        // Act
        var output = await createShippingUseCase.Execute(input, CancellationToken.None);

        // Assert
        Assert.NotEmpty(output.ShippingId);
    }

    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldReturnDomainValidationExceptionWithMessage()
    {
        // Arrange
        var createShippingUseCase = CreateShippingFixture.CreateUseCase();
        var input = CreateShippingFixture.CreateInvalidInput();
        
        // Act
        var exception = await Record.ExceptionAsync(() => createShippingUseCase.Execute(input, CancellationToken.None));
    
        // Assert
        var entityValidationException = Assert.IsType<EntityValidationException>(exception);
        Assert.NotEmpty(entityValidationException.Errors);
    }
    
}