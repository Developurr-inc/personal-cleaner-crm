using Orderly.Domain.SalesConsultant;
using Orderly.Domain.SalesConsultant.ValueObjects;

namespace Orderly.Application.UseCase.SalesConsultant.GetSalesConsultant;

public class GetSalesConsultantUseCase : IUseCase<GetSalesConsultantInput, GetSalesConsultantOutput>
{
    private readonly ISalesConsultantRepository _salesConsultantRepository;
    
    public GetSalesConsultantUseCase(ISalesConsultantRepository salesConsultantRepository)
    {
        _salesConsultantRepository = salesConsultantRepository;
    }
    
    public async Task<GetSalesConsultantOutput> Execute(
        GetSalesConsultantInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultantId = SalesConsultantId.Restore(input.SalesConsultantId);
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(salesConsultantId, cancellationToken);

        return new GetSalesConsultantOutput(
            salesConsultant.Cpf.Value,
            salesConsultant.Address.Street, //Fix add ToString
            salesConsultant.Name,
            salesConsultant.Email.Value,
            salesConsultant.Landline?.Value ?? "",
            salesConsultant.Mobile?.Value ?? ""
        );
    }
}