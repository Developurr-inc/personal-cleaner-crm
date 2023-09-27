using Orderly.Domain.SalesConsultant;
using Orderly.Domain.SalesConsultant.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Application.UseCase.SalesConsultant.CreateSalesConsultant;

public sealed class CreateSalesConsultantUseCase
    : IUseCase<CreateSalesConsultantInput, CreateSalesConsultantOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public CreateSalesConsultantUseCase(
        IUnitOfWork unitOfWork,
        ISalesConsultantRepository salesConsultantRepository
    )
    {
        _unitOfWork = unitOfWork;
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<CreateSalesConsultantOutput> Execute(
        CreateSalesConsultantInput input,
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

        return new CreateSalesConsultantOutput(salesConsultant.Id.Format());
    }
}
