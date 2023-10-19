using Developurr.Orderly.Domain.SalesConsultant.Repositories;

namespace Developurr.Orderly.Application.Command.Vendor.CreateVendor;

public sealed class CreateVendorUseCase
    : IUseCase<CreateVendorInput, CreateVendorOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public CreateVendorUseCase(
        IUnitOfWork unitOfWork,
        ISalesConsultantRepository salesConsultantRepository
    )
    {
        _unitOfWork = unitOfWork;
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<CreateVendorOutput> Handle(
        CreateVendorInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultant = Domain.SalesConsultant.SalesConsultant.Create(
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

        await _salesConsultantRepository.InsertAsync(salesConsultant, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateVendorOutput(salesConsultant.Id.Format());
    }
}
