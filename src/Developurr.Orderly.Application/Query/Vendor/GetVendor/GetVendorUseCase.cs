using Developurr.Orderly.Application.Exceptions;
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
        var vendor = await _vendorRepository.GetByIdAsync(input.VendorId, cancellationToken);

        if (vendor is null)
            throw new NotFoundException(nameof(input.VendorId));

        return new GetVendorOutput(
            vendor.Cpf.ToString(),
            vendor.Address.ToString(),
            vendor.Name.ToString(),
            vendor.Email.ToString(),
            vendor.Landline?.Value ?? "",
            vendor.Mobile?.Value ?? ""
        );
    }
}