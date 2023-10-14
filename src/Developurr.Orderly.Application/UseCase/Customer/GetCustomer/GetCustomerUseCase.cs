<<<<<<<< HEAD:src/Orderly.Application/Query/Customer/GetCustomerUseCase.cs
using Orderly.Application.Command;
using Orderly.Domain.Customer;

namespace Orderly.Application.Query.Customer;
========
using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Domain.Customer;

namespace Developurr.Orderly.Application.UseCase.Customer.GetCustomer;
>>>>>>>> develop:src/Developurr.Orderly.Application/UseCase/Customer/GetCustomer/GetCustomerUseCase.cs

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
            customer.Cnpj.Format(),
            customer.CorporateName,
            customer.TaxId,
            customer.TradeName,
            customer.Segment,
            customer.BillingEmail?.Format() ?? "",
            customer.NfeEmail.Format(),
            customer.Landline?.Value ?? "",
            customer.Mobile?.Value ?? "",
            customer.Observation
        );
    }
}
