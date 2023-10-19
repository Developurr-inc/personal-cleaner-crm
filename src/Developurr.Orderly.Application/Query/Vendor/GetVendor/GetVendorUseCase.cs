using Developurr.Orderly.Domain.SalesConsultant.Repositories;

namespace Developurr.Orderly.Application.Query.Vendor.GetVendor;

public class GetVendorUseCase : IUseCase<GetVendorInput, GetVendorOutput>
{
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public GetVendorUseCase(ISalesConsultantRepository salesConsultantRepository)
    {
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<GetVendorOutput> Handle(
        GetVendorInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(
            input.SalesConsultantId,
            cancellationToken
        );

        return new GetVendorOutput(
            salesConsultant.Cpf.Format(),
            salesConsultant.Address.Format(),
            salesConsultant.Name,
            salesConsultant.Email.Format(),
            salesConsultant.Landline?.Value ?? "",
            salesConsultant.Mobile?.Value ?? ""
        );
    }
}
