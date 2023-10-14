using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Domain.Product;

namespace Developurr.Orderly.Application.UseCase.Product.GetProduct;

public class GetProductUseCase : IUseCase<GetProductInput, GetProductOutput>
{
    private readonly IProductRepository _productRepository;

    public GetProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetProductOutput> Execute(
        GetProductInput input,
        CancellationToken cancellationToken
    )
    {
        var product = await _productRepository.GetByIdAsync(
            input.ProductId,
            cancellationToken
        );

        return new GetProductOutput(
            product.Code,
            product.Name,
            product.Packaging,
            product.ExciseTax,
            product.Price.Value
        );
    }
}
