using Developurr.Orderly.Application.Exceptions;
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
        var shipping = await _shippingRepository.GetByIdAsync(input.ShippingId, cancellationToken);

        if (shipping is null)
            throw new IdNotFoundException(input.ShippingId);

        return new GetShippingOutput(
            shipping.Cnpj.ToString(),
            shipping.RazaoSocial.ToString(),
            shipping.InscricaoSocial.ToString(),
            shipping.NomeFantasia.ToString(),
            shipping.Segment.ToString()
        );
    }
}
