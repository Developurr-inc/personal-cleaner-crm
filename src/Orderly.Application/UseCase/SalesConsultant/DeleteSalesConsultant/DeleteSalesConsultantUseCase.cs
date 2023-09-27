using Orderly.Domain.SalesConsultant;

namespace Orderly.Application.UseCase.SalesConsultant.DeleteSalesConsultant;

public class DeleteSalesConsultantUseCase
    : IUseCase<DeleteSalesConsultantInput, DeleteSalesConsultantOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public DeleteSalesConsultantUseCase(
        IUnitOfWork unitOfWork,
        ISalesConsultantRepository salesConsultantRepository
    )
    {
        _unitOfWork = unitOfWork;
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<DeleteSalesConsultantOutput> Execute(
        DeleteSalesConsultantInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(
            input.SalesConsultantId,
            cancellationToken
        );

        await _salesConsultantRepository.RemoveAsync(salesConsultant, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteSalesConsultantOutput(salesConsultant.Id.Format());
    }
}
