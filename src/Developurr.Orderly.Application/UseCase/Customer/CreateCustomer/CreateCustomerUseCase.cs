using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Domain.Customer;
using Developurr.Orderly.Domain.SalesConsultant;

namespace Developurr.Orderly.Application.UseCase.Customer.CreateCustomer;

public sealed class CreateCustomerUseCase : IUseCase<CreateCustomerInput, CreateCustomerOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public CreateCustomerUseCase(
        IUnitOfWork unitOfWork,
        ICustomerRepository customerRepository,
        ISalesConsultantRepository salesConsultantRepository
    )
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<CreateCustomerOutput> Execute(
        CreateCustomerInput input,
        CancellationToken cancellationToken
    )
    {
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(
            input.SalesConsultantId,
            cancellationToken
        );

        var customer = Domain.Customer.Customer.Create(
            salesConsultant.Id,
            input.Cnpj,
            input.CorporateName,
            input.TaxId,
            input.TradeName,
            input.Segment,
            input.BillingEmail,
            input.NfeEmail,
            input.Landline,
            input.Mobile,
            input.Observation
        );

        await _customerRepository.InsertAsync(customer, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateCustomerOutput(customer.Id.Format());
    }
}
