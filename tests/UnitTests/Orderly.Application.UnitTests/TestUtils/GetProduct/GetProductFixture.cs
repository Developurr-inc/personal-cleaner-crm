using Moq;
using Orderly.Application.UseCase;
using Orderly.Application.UseCase.Product.CreateProduct;
using Orderly.Application.UseCase.Product.GetProduct;
using Orderly.Domain.Product;
using Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Orderly.Application.UnitTests.TestUtils.GetProduct;

public static class GetProductFixture
{
    public static GetProductUseCase GetUseCase()
    {
        var productRepositoryMock = new Mock<IProductRepository>();
        

        return new GetProductUseCase(productRepositoryMock.Object);
    }
    
    public static GetProductInput GetInput()
    {
        return new GetProductInput(
            Constants.ProductId.Id.Format()
        );
    }
    
    // public static GetProductInput GetInvalidInput()
    // {
    //     return new GetProductInput(
    //         ""
    //     );
    // }
}