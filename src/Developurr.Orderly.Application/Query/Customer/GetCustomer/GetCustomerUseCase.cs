using Developurr.Orderly.Domain.Customer;

namespace Developurr.Orderly.Application.Query.Customer.GetCustomer;

public sealed class GetCustomerUseCase : IQuery<GetCustomerInput, GetCustomerOutput>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetCustomerOutput> Handle(
        GetCustomerInput input,
        CancellationToken cancellationToken
    )
    {
        var customer = await _customerRepository.GetByIdAsync(
            input.CustomerId,
            cancellationToken
        );

        return new GetCustomerOutput(
            customer.Id.Format(),
            customer.SalesConsultant.Format(),
            customer.Cnpj.Format(),
            customer.CorporateName,
            customer.TaxId,
            customer.TradeName,
            customer.Segment,
            customer.BillingEmail.Format(),
            customer.NfeEmail.Format(),
            customer.Landline.Value,
            customer.Mobile.Value,
            customer.Observation
        );
    }
}
