using Developurr.Orderly.Domain.Product.Repositories;

namespace Developurr.Orderly.Application.UseCase.Product.GetProduct;

public class GetProductUseCase : IUseCase<GetProductInput, GetProductOutput>
{
    private readonly IProductRepository _productRepository;

    public GetProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetProductOutput> Handle(
        GetProductInput input,
        CancellationToken cancellationToken
    )
    {
        var product = await _productRepository.GetByIdAsync(input.ProductId, cancellationToken);
        
        if (product is null)
        {
            throw new ArgumentException(input.ProductId);
        }
        
        return new GetProductOutput(
            product.Id.Format(),
            product.Name.Value,
            product.Description.Value,
            product.CategoryId.ToString(),
            product.PackageId.ToString(),
            product.UnitPrice.Value,
            product.Imposto.Value
        );
    }
}
