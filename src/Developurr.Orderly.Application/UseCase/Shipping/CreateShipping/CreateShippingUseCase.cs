using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Domain.Shipping.Repositories;

namespace Developurr.Orderly.Application.UseCase.Shipping.CreateShipping;

public sealed class CreateShippingUseCase : IUseCase<CreateShippingInput, CreateShippingOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IShippingRepository _shippingRepository;

    public CreateShippingUseCase(
        IUnitOfWork unitOfWork,
        IShippingRepository shippingRepository
    )
    {
        _unitOfWork = unitOfWork;
        _shippingRepository = shippingRepository;
    }
    
    public async Task<CreateShippingOutput> Handle(
        CreateShippingInput input,
        CancellationToken cancellationToken
    )
    {
        var shipping = Domain.Shipping.Shipping.Create(
            input.Cnpj,
            input.CorporateName,
            input.TaxId,
            input.TradeName,
            input.Segment
            );
        
        await _shippingRepository.InsertAsync(shipping, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateShippingOutput(shipping.Id.Format());
    }
}