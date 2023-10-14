using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.UseCase.Product.CreateProduct;
using Developurr.Orderly.Domain.Product;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.CreateProduct;

public static class CreateProductFixture
{
    public static CreateProductUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        

        return new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object);
    }
    
    public static CreateProductInput CreateInput()
    {
        return new CreateProductInput(
            Constants.Product.Code,
            Constants.Product.Name,
            Constants.Product.Packaging,
            Constants.Product.ExciseTax,
            Constants.Price.PriceValue
        );
    }
    
    public static CreateProductInput CreateInvalidInput()
    {
        return new CreateProductInput(
            Constants.Product.Code,
            "Name",
            Constants.Product.Packaging,
            Constants.Product.ExciseTax,
            Constants.Price.PriceValue
        );
    }
}