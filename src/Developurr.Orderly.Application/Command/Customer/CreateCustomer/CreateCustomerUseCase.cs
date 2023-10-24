using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.Vendor.Repositories;

namespace Developurr.Orderly.Application.Command.Customer.CreateCustomer;

public sealed class CreateCustomerUseCase : ICommand<CreateCustomerInput, CreateCustomerOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;
    private readonly IVendorRepository _vendorRepository;

    public CreateCustomerUseCase(
        IUnitOfWork unitOfWork,
        ICustomerRepository customerRepository,
        IVendorRepository vendorRepository
    )
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
        _vendorRepository = vendorRepository;
    }

    public async Task<CreateCustomerOutput> Handle(
        CreateCustomerInput input,
        CancellationToken cancellationToken
    )
    {
        var vendor = await _vendorRepository.GetByIdAsync(input.VendorId, cancellationToken);

        if (vendor is null)
            throw new NotFoundException(input.VendorId);

        var customer = Domain.Customer.Customer.Create(
            vendor.Id,
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

        return new CreateCustomerOutput(customer.Id.ToString());
    }
}