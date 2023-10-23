using Developurr.Orderly.Domain.Vendor.Repositories;

namespace Developurr.Orderly.Application.Command.Vendor.CreateVendor;

public sealed class CreateVendorUseCase : IUseCase<CreateVendorInput, CreateVendorOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVendorRepository _vendorRepository;

    public CreateVendorUseCase(IUnitOfWork unitOfWork, IVendorRepository vendorRepository)
    {
        _unitOfWork = unitOfWork;
        _vendorRepository = vendorRepository;
    }

    public async Task<CreateVendorOutput> Handle(
        CreateVendorInput input,
        CancellationToken cancellationToken
    )
    {
        var vendor = Domain.Vendor.Vendor.Create(
            input.Cpf,
            input.Street,
            input.Number,
            input.Complement,
            input.ZipCode,
            input.Neighborhood,
            input.City,
            input.State,
            input.Country,
            input.Name,
            input.Email,
            input.Landline,
            input.Mobile
        );

        await _vendorRepository.InsertAsync(vendor, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateVendorOutput(vendor.Id.ToString());
    }
}
