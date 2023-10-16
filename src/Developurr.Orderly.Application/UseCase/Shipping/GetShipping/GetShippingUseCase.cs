using Developurr.Orderly.Domain.Shipping.Repositories;

namespace Developurr.Orderly.Application.UseCase.Shipping.GetShipping;

public class GetShippingUseCase : IUseCase<GetShippingInput, GetShippingOutput>
{
    private readonly IShippingRepository _shippingRepository;

    public GetShippingUseCase(IShippingRepository shippingRepository)
    {
        _shippingRepository = shippingRepository;
    }

    public async Task<GetShippingOutput> Handle(
        GetShippingInput input,
        CancellationToken cancellationToken
    )
    {
        var shipping = await _shippingRepository.GetByIdAsync(
            input.ShippingId,
            cancellationToken
        );

        return new GetShippingOutput(
            shipping.Cnpj.Format(),
            shipping.CorporateName,
            shipping.TaxId,
            shipping.TradeName,
            shipping.Segment
            );
    }
}
    