using Orderly.Domain.Customer;
using Orderly.Domain.Customer.ValueObjects;

namespace Orderly.Application.UseCase.Customer.GetCustomer;

public class GetCustomerUseCase : IUseCase<GetCustomerInput, GetCustomerOutput>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetCustomerOutput> Execute(
        GetCustomerInput input,
        CancellationToken cancellationToken
    )
    {
        var customer = await _customerRepository.GetByIdAsync(input.CustomerId, cancellationToken);

        return new GetCustomerOutput(
            customer.Cnpj.Value,
            customer.CorporateName,
            customer.TaxId,
            customer.TradeName,
            customer.Segment,
            customer.BillingEmail?.Value ?? "",
            customer.NfeEmail.Value,
            customer.Landline?.Value ?? "",
            customer.Mobile?.Value ?? "",
            customer.Observation
        );
    }
}
