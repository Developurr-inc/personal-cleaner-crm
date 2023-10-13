using Developurr.Orderly.Domain.Shipping;

namespace Developurr.Orderly.Application.UseCase.Shipping.DeleteShipping;

public class DeleteShippingUseCase
    : IUseCase<DeleteShippingInput, DeleteShippingOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IShippingRepository _shippingRepository;

    public DeleteShippingUseCase(
        IUnitOfWork unitOfWork,
        IShippingRepository shippingRepository
    )
    {
        _unitOfWork = unitOfWork;
        _shippingRepository = shippingRepository;
    }

    public async Task<DeleteShippingOutput> Execute(
        DeleteShippingInput input,
        CancellationToken cancellationToken
    )
    {
        var shipping = await _shippingRepository.GetByIdAsync(
            input.ShippingId,
            cancellationToken
        );

        await _shippingRepository.RemoveAsync(shipping, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteShippingOutput(shipping.Id.Format());
    }
}
