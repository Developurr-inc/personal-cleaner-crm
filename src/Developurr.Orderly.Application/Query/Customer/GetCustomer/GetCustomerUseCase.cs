using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Customer.Repositories;

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
        var customer = await _customerRepository.GetByIdAsync(input.CustomerId, cancellationToken);

        if (customer is null)
            throw new IdNotFoundException(nameof(input.CustomerId));

        return new GetCustomerOutput(
            customer.Id.ToString(),
            customer.Vendor.ToString(),
            customer.Cnpj.ToString(),
            customer.RazaoSocial.ToString(),
            customer.InscricaoSocial.ToString(),
            customer.NomeFantasia.ToString(),
            customer.Segmento.ToString(),
            customer.BillingEmail?.ToString() ?? "",
            customer.NfeEmail.ToString(),
            customer.Landline?.Value ?? "",
            customer.Mobile?.Value ?? "",
            customer.Observation.ToString()
        );
    }
}
