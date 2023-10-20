using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Customer.Repositories;

namespace Developurr.Orderly.Application.Command.Customer.DeleteCustomer;

public class DeleteCustomerUseCase : ICommand<DeleteCustomerInput, DeleteCustomerOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerUseCase(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<DeleteCustomerOutput> Handle(
        DeleteCustomerInput input,
        CancellationToken cancellationToken
    )
    {
        var customer = await _customerRepository.GetByIdAsync(input.CustomerId, cancellationToken);
        if (customer is null)
            throw new NotFoundException("Customer not found.", nameof(input.CustomerId));

        customer.Disable();
        await _customerRepository.UpdateAsync(customer, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteCustomerOutput(customer.Id.Format());
    }
}