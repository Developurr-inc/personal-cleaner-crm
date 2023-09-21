using Orderly.Domain.SalesConsultant;
using Orderly.Domain.SalesConsultant.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Application.UseCase.SalesConsultant.DeleteSalesConsultant;

public class DeleteSalesConsultantUseCase : IUseCase<DeleteSalesConsultantInput, DeleteSalesConsultantOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISalesConsultantRepository _salesConsultantRepository;   
    
    public DeleteSalesConsultantUseCase(IUnitOfWork unitOfWork, ISalesConsultantRepository salesConsultantRepository)
    {
        _unitOfWork = unitOfWork;
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<DeleteSalesConsultantOutput> Execute(
        DeleteSalesConsultantInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultantId = SalesConsultantId.Restore(input.SalesConsultantId);
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(salesConsultantId, cancellationToken);

        await _salesConsultantRepository.RemoveAsync(salesConsultant, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        
        return new DeleteSalesConsultantOutput(salesConsultantId.Value.ToString());
    }
}