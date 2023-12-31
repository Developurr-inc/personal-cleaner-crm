using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Category.Repositories;
using Developurr.Orderly.Domain.Package.Repositories;
using Developurr.Orderly.Domain.Product.Repositories;

namespace Developurr.Orderly.Application.Command.Product.CreateProduct;

public sealed class CreateProductUseCase : IUseCase<CreateProductInput, CreateProductOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPackageRepository _packageRepository;

    public CreateProductUseCase(
        IUnitOfWork unitOfWork,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IPackageRepository packageRepository
    )
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _packageRepository = packageRepository;
    }

    public async Task<CreateProductOutput> Handle(
        CreateProductInput input,
        CancellationToken cancellationToken
    )
    {
        var category = await _categoryRepository.GetByIdAsync(input.CategoryId, cancellationToken);
        var package = await _packageRepository.GetByIdAsync(input.PackageId, cancellationToken);

        if (category is null)
            throw new IdNotFoundException(nameof(input.CategoryId));

        if (package is null)
            throw new IdNotFoundException(nameof(input.PackageId));

        var product = Domain.Product.Product.Create(
            input.Name,
            input.Description,
            category.Id,
            package.Id,
            input.UnitPrice,
            input.Imposto
        );

        await _productRepository.InsertAsync(product, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateProductOutput(product.Id.ToString());
    }
}
