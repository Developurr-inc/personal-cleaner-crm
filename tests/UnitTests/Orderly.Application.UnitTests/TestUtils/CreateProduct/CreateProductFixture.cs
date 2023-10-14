using Moq;
using Orderly.Application.UseCase;
using Orderly.Application.UseCase.Product.CreateProduct;
using Orderly.Domain.Product;
using Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Orderly.Application.UnitTests.TestUtils.CreateProduct;

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