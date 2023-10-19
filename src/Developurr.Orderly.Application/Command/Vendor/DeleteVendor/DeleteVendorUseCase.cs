using Developurr.Orderly.Domain.SalesConsultant.Repositories;

namespace Developurr.Orderly.Application.Command.Vendor.DeleteVendor;

public class DeleteVendorUseCase
    : IUseCase<DeleteVendorInput, DeleteVendorOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public DeleteVendorUseCase(
        IUnitOfWork unitOfWork,
        ISalesConsultantRepository salesConsultantRepository
    )
    {
        _unitOfWork = unitOfWork;
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<DeleteVendorOutput> Handle(
        DeleteVendorInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(
            input.SalesConsultantId,
            cancellationToken
        );

        await _salesConsultantRepository.RemoveAsync(salesConsultant, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteVendorOutput(salesConsultant.Id.Format());
    }
}
