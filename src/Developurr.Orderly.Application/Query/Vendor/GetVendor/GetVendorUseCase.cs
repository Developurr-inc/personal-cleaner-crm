using Developurr.Orderly.Domain.Vendor.Repositories;

namespace Developurr.Orderly.Application.Query.Vendor.GetVendor;

public class GetVendorUseCase : IUseCase<GetVendorInput, GetVendorOutput>
{
    private readonly IVendorRepository _vendorRepository;

    public GetVendorUseCase(IVendorRepository vendorRepository)
    {
        _vendorRepository = vendorRepository;
    }

    public async Task<GetVendorOutput> Handle(
        GetVendorInput input,
        CancellationToken cancellationToken
    )
    {
        var vendor = await _vendorRepository.GetByIdAsync(
            input.VendorId,
            cancellationToken
        );

        return new GetVendorOutput(
            vendor.Cpf.Format(),
            vendor.Address.Format(),
            vendor.Name,
            vendor.Email.Format(),
            vendor.Landline?.Value ?? "",
            vendor.Mobile?.Value ?? ""
        );
    }
}
