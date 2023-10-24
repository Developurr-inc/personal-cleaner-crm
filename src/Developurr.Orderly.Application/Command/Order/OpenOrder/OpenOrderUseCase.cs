using Developurr.Orderly.Application.Exceptions;
using Developurr.Orderly.Domain.Customer.Repositories;
using Developurr.Orderly.Domain.Order.Repositories;
using Developurr.Orderly.Domain.Vendor.Repositories;

namespace Developurr.Orderly.Application.Command.Order.OpenOrder;

public sealed class OpenOrderUseCase : ICommand<OpenOrderInput, OpenOrderOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IVendorRepository _vendorRepository;

    public OpenOrderUseCase(
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        IVendorRepository vendorRepository
    )
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _vendorRepository = vendorRepository;
    }

    public async Task<OpenOrderOutput> Handle(
        OpenOrderInput input,
        CancellationToken cancellationToken
    )
    {
        var customer = await _customerRepository.GetByIdAsync(input.CustomerId, cancellationToken);
        var vendor = await _vendorRepository.GetByIdAsync(input.VendorId, cancellationToken);

        if (customer is null)
            throw new NotFoundException(nameof(input.CustomerId));

        if (vendor is null)
            throw new NotFoundException(nameof(input.VendorId));

        var order = Domain.Order.Order.Open(customer.Id, vendor.Id);

        await _orderRepository.InsertAsync(order, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new OpenOrderOutput(order.Id.ToString());
    }
}