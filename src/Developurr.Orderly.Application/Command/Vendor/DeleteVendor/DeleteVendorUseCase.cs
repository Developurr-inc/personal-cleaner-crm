using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Vendor.Repositories;

namespace Developurr.Orderly.Application.Command.Vendor.DeleteVendor;

public class DeleteVendorUseCase : IUseCase<DeleteVendorInput, DeleteVendorOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVendorRepository _vendorRepository;

    public DeleteVendorUseCase(IUnitOfWork unitOfWork, IVendorRepository vendorRepository)
    {
        _unitOfWork = unitOfWork;
        _vendorRepository = vendorRepository;
    }

    public async Task<DeleteVendorOutput> Handle(
        DeleteVendorInput input,
        CancellationToken cancellationToken
    )
    {
        var vendor = await _vendorRepository.GetByIdAsync(input.VendorId, cancellationToken);
        if (vendor is null)
            throw new IdNotFoundException(nameof(input.VendorId));

        vendor.Deactivate();

        await _vendorRepository.UpdateAsync(vendor, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteVendorOutput(vendor.Id.ToString());
    }
}
