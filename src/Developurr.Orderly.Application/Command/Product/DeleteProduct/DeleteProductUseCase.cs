using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Product.Repositories;

namespace Developurr.Orderly.Application.Command.Product.DeleteProduct;

public class DeleteProductUseCase : IUseCase<DeleteProductInput, DeleteProductOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public DeleteProductUseCase(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<DeleteProductOutput> Handle(
        DeleteProductInput input,
        CancellationToken cancellationToken
    )
    {
        var product = await _productRepository.GetByIdAsync(input.ProductId, cancellationToken);

        if (product is null)
            throw new NotFoundException(nameof(input.ProductId));

        product.Deactivate();

        await _productRepository.UpdateAsync(product, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteProductOutput(product.Id.ToString());
    }
}