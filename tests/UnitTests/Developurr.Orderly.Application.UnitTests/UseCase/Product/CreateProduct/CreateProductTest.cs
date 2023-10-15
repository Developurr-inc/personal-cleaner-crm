using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.UnitTests.TestUtils.CreateProduct;
using Developurr.Orderly.Application.UseCase.Product.CreateProduct;
using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Product.Repositories;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.UseCase.Product.CreateProduct;

public class CreateProductTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingCreateProductUseCase_ThenShouldInstantiateCreateProductUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();

        // Act
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object);

        // Assert
        Assert.NotNull(createProductUseCase);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();
        
        

        // Act
        _ = await createProductUseCase.Handle(input, CancellationToken.None);
        
        // Assert
        productRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Product.Product>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldCallCommitAsyncOnce()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();
        
        // Act
        _ = await createProductUseCase.Handle(input, CancellationToken.None);
        
        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnValidOutput()
    {
        // Arrange
        var createProductUseCase = CreateProductFixture.CreateUseCase();
        var input = CreateProductFixture.CreateInput();

        // Act
        var output = await createProductUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotNull(output);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnOutput()
    {
        // Arrange
        var createProductUseCase = CreateProductFixture.CreateUseCase();
        var input = CreateProductFixture.CreateInput();

        // Act
        var output = await createProductUseCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.NotEmpty(output.ProductId);
    }
    
    [Fact]
    public async void GivenInvalidInput_WhenCallingExecute_ThenShouldReturnDomainValidationExceptionWithMessage()
    {
        // Arrange
        var createProductUseCase = CreateProductFixture.CreateUseCase();
        var input = CreateProductFixture.CreateInvalidInput();
        
        // Act
        var exception = await Record.ExceptionAsync(() => createProductUseCase.Handle(input, CancellationToken.None));
    
        // Assert
        var entityValidationException = Assert.IsType<EntityValidationException>(exception);
        Assert.NotEmpty(entityValidationException.Errors);
    }
}