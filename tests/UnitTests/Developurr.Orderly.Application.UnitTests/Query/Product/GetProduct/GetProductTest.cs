namespace Developurr.Orderly.Application.UnitTests.Query.Product.GetProduct;

public class GetProductTest
{
    // [Fact]
    // public void GivenValidInput_WhenInstantiatingGetProductUseCase_ThenShouldInstantiateGetProductUseCase()
    // {
    //     // Arrange
    //     var productRepositoryMock = new Mock<IProductRepository>();
    //
    //     // Act
    //     var getProductUseCase = new GetProductUseCase(productRepositoryMock.Object);
    //
    //     // Assert
    //     Assert.NotNull(getProductUseCase);
    // }
    //
    // [Fact]
    // public async void GivenValidInput_WhenCallingExecute_ThenShouldCallInsertAsyncOnce()
    // {
    //     // Arrange
    //     var productRepositoryMock = new Mock<IProductRepository>();
    //     var getProductUseCase = new GetProductUseCase(productRepositoryMock.Object);
    //     var input = GetProductFixture.GetInput();
    //
    //
    //
    //     // Act
    //     _ = await getProductUseCase.Execute(input, CancellationToken.None);
    //
    //     // Assert
    //     productRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Product.Product>(), CancellationToken.None), Times.Once);
    // }
    //
    // [Fact]
    // public async void GivenValidInput_WhenCallingExecute_ThenShouldReturnValidOutput()
    // {
    //     // Arrange
    //     var getProductUseCase = GetProductFixture.GetUseCase();
    //     var input = GetProductFixture.GetInput();
    //
    //     // Act
    //     var output = await getProductUseCase.Execute(input, CancellationToken.None);
    //
    //     // Assert
    //     Assert.NotNull(output);
    // }

    // [Fact]
    // public async void GivenInvalidInput_WhenCallingExecute_ThenShouldReturnDomainValidationExceptionWithMessage()
    // {
    //     // Arrange
    //     var createProductUseCase = GetProductFixture.GetUseCase();
    //     var input = GetProductFixture.GetInvalidInput();
    //
    //     // Act
    //     var exception = await Record.ExceptionAsync(() => createProductUseCase.Execute(input, CancellationToken.None));
    //
    //     // Assert
    //     var entityValidationException = Assert.IsType<DomainValidationException>(exception);
    //     Assert.NotEmpty(entityValidationException.Errors);
    // }
}
