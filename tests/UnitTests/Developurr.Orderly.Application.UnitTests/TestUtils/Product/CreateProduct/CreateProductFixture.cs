using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Product.CreateProduct;
using Developurr.Orderly.Domain.Category.Repositories;
using Developurr.Orderly.Domain.Package.Repositories;
using Developurr.Orderly.Domain.Product.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Category;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Package;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.TestUtils.Product.CreateProduct;

public static class CreateProductFixture
{
    public static CreateProductUseCase CreateUseCase()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var input = CreateInput();

        categoryRepositoryMock
            .Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(CategoryFixture.CreateCategory());
        packageRepositoryMock
            .Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(PackageFixture.CreatePackage());

        return new CreateProductUseCase(
            unitOfWorkMock.Object,
            productRepositoryMock.Object,
            categoryRepositoryMock.Object,
            packageRepositoryMock.Object
        );
    }

    public static CreateProductInput CreateInput()
    {
        return new CreateProductInput("Produto", "Descrição do produto", "1", "1", 10m, 0.1m);
    }
}
