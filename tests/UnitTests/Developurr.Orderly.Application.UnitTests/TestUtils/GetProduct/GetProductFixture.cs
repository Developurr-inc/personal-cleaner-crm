using Developurr.Orderly.Application.Query.Product.GetProduct;
using Developurr.Orderly.Domain.Product.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.GetProduct;

public static class GetProductFixture
{
    public static GetProductUseCase GetUseCase()
    {
        var productRepositoryMock = new Mock<IProductRepository>();

        return new GetProductUseCase(productRepositoryMock.Object);
    }

    public static GetProductInput GetInput()
    {
        return new GetProductInput(Constants.CustomerId.Id.ToString());
    }
}
