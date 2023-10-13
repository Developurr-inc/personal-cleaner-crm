using Orderly.Application.Command;
using Orderly.Domain.Product;

namespace Orderly.Application.UseCase.Product.CreateProduct;

public sealed class CreateProductUseCase : IUseCase<CreateProductInput, CreateProductOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public CreateProductUseCase(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<CreateProductOutput> Execute(
        CreateProductInput input,
        CancellationToken cancellationToken
    )
    {
        var product = Domain.Product.Product.Create(
            input.Code,
            input.Name,
            input.Packaging,
            input.ExciseTax,
            input.PriceValue
        );

        await _productRepository.InsertAsync(product, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateProductOutput(product.Id.Format());
    }
}