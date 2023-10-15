using Developurr.Orderly.Domain.SalesConsultant.Repositories;

namespace Developurr.Orderly.Application.UseCase.SalesConsultant.GetSalesConsultant;

public class GetSalesConsultantUseCase : IUseCase<GetSalesConsultantInput, GetSalesConsultantOutput>
{
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public GetSalesConsultantUseCase(ISalesConsultantRepository salesConsultantRepository)
    {
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<GetSalesConsultantOutput> Handle(
        GetSalesConsultantInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(
            input.SalesConsultantId,
            cancellationToken
        );

        return new GetSalesConsultantOutput(
            salesConsultant.Cpf.Format(),
            salesConsultant.Address.Format(),
            salesConsultant.Name,
            salesConsultant.Email.Format(),
            salesConsultant.Landline?.Value ?? "",
            salesConsultant.Mobile?.Value ?? ""
        );
    }
}
