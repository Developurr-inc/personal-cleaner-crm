using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Application.Command.Product.CreateProduct;
using Developurr.Orderly.Application.UnitTests.TestUtils.Product.CreateProduct;
using Developurr.Orderly.Domain.Category.Repositories;
using Developurr.Orderly.Domain.Package.Repositories;
using Developurr.Orderly.Domain.Product.Repositories;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Category;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Package;
using Moq;

namespace Developurr.Orderly.Application.UnitTests.Command.Product.CreateProduct;

public class CreateProductTest
{
    [Fact]
    public void GivenValidInput_WhenInstantiatingCreateProductUseCase_ThenShouldInstantiateCreateProductUseCase()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();

        // Act
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);

        // Assert
        Assert.NotNull(createProductUseCase);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingHandle_ThenShouldHaveValidOutput()
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
    public async void GivenValidInput_WhenCallingHandle_ThenShouldCallGetByIdAsyncOnCategoryRepository()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        categoryRepositoryMock.Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>())).ReturnsAsync(CategoryFixture.CreateCategory());
        packageRepositoryMock.Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>())).ReturnsAsync(PackageFixture.CreatePackage());

        // Act
        await createProductUseCase.Handle(input, CancellationToken.None);

        // Assert
        categoryRepositoryMock.Verify(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingHandle_ThenShouldCallGetByIdAsyncOnPackageRepository()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        categoryRepositoryMock.Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>())).ReturnsAsync(CategoryFixture.CreateCategory());
        packageRepositoryMock.Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>())).ReturnsAsync(PackageFixture.CreatePackage());

        // Act
        await createProductUseCase.Handle(input, CancellationToken.None);

        // Assert
        packageRepositoryMock.Verify(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async void GivenValidInput_WhenCallingHandle_ThenShouldCallInsertAsyncOnProductRepository()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        categoryRepositoryMock.Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>())).ReturnsAsync(CategoryFixture.CreateCategory());
        packageRepositoryMock.Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>())).ReturnsAsync(PackageFixture.CreatePackage());

        // Act
        await createProductUseCase.Handle(input, CancellationToken.None);

        // Assert
        productRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Product.Product>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GivenValidInput_WhenCallingHandle_ThenShouldCallCommitAsyncOnUnitOfWork()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        categoryRepositoryMock.Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>())).ReturnsAsync(CategoryFixture.CreateCategory());
        packageRepositoryMock.Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>())).ReturnsAsync(PackageFixture.CreatePackage());

        // Act
        await createProductUseCase.Handle(input, CancellationToken.None);

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async void GivenInvalidCategory_WhenCallingHandle_ThenShouldThrowException()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();
        var expectedMessage = "Category not found. (Parameter 'CategoryId')";

        packageRepositoryMock.Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>())).ReturnsAsync(PackageFixture.CreatePackage());

        // Act
        var exception = await Record.ExceptionAsync(() => createProductUseCase.Handle(input, CancellationToken.None));

        // Assert
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public async void GivenInvalidPackage_WhenCallingHandle_ThenShouldThrowException()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();
        var expectedMessage = "Package not found. (Parameter 'PackageId')";

        categoryRepositoryMock.Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>())).ReturnsAsync(CategoryFixture.CreateCategory());

        // Act
        var exception = await Record.ExceptionAsync(() => createProductUseCase.Handle(input, CancellationToken.None));

        // Assert
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal(expectedMessage, exception.Message);
    }
    
    [Fact]
    public async void GivenInvalidCategory_WhenCallingHandle_ThenShouldNotCallInsertAsyncOnProductRepository()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        packageRepositoryMock.Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>())).ReturnsAsync(PackageFixture.CreatePackage());

        // Act
        _ = await Record.ExceptionAsync(() => createProductUseCase.Handle(input, CancellationToken.None));

        // Assert
        productRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Product.Product>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async void GivenInvalidCategory_WhenCallingHandle_ThenShouldNotCallCommitAsyncOnUnitOfWork()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        packageRepositoryMock.Setup(x => x.GetByIdAsync(input.PackageId, It.IsAny<CancellationToken>())).ReturnsAsync(PackageFixture.CreatePackage());

        // Act
        _ = await Record.ExceptionAsync(() => createProductUseCase.Handle(input, CancellationToken.None));

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
    
    [Fact]
    public async void GivenInvalidPackage_WhenCallingHandle_ThenShouldNotCallInsertAsyncOnProductRepository()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        categoryRepositoryMock.Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>())).ReturnsAsync(CategoryFixture.CreateCategory());

        // Act
        _ = await Record.ExceptionAsync(() => createProductUseCase.Handle(input, CancellationToken.None));

        // Assert
        productRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Domain.Product.Product>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async void GivenInvalidPackage_WhenCallingHandle_ThenShouldNotCallCommitAsyncOnUnitOfWork()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var packageRepositoryMock = new Mock<IPackageRepository>();
        var createProductUseCase = new CreateProductUseCase(unitOfWorkMock.Object, productRepositoryMock.Object, categoryRepositoryMock.Object, packageRepositoryMock.Object);
        var input = CreateProductFixture.CreateInput();

        categoryRepositoryMock.Setup(x => x.GetByIdAsync(input.CategoryId, It.IsAny<CancellationToken>())).ReturnsAsync(CategoryFixture.CreateCategory());

        // Act
        _ = await Record.ExceptionAsync(() => createProductUseCase.Handle(input, CancellationToken.None));

        // Assert
        unitOfWorkMock.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}