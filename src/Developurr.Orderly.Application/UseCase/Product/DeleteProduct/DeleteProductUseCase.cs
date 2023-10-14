using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Domain.Product;

namespace Developurr.Orderly.Application.UseCase.Product.DeleteProduct;

public class DeleteProductUseCase : IUseCase<DeleteProductInput, DeleteProductOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public DeleteProductUseCase(
        IUnitOfWork unitOfWork,
        IProductRepository productRepository
    )
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<DeleteProductOutput> Execute(
        DeleteProductInput input,
        CancellationToken cancellationToken
        )
    {
        var product = await _productRepository.GetByIdAsync(
            input.ProductId,
            cancellationToken
        );

        await _productRepository.RemoveAsync(product, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteProductOutput(product.Id.Format());
    }
}