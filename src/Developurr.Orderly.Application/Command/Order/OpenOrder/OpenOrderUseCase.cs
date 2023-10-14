using Developurr.Orderly.Domain.Customer;
using Developurr.Orderly.Domain.Order;
using Developurr.Orderly.Domain.SalesConsultant;

namespace Developurr.Orderly.Application.Command.Order.OpenOrder;

public sealed class OpenOrderUseCase : IUseCase<OpenOrderInput, OpenOrderOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISalesConsultantRepository _salesConsultantRepository;

    public OpenOrderUseCase(
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        ISalesConsultantRepository salesConsultantRepository
        
    )
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _salesConsultantRepository = salesConsultantRepository;
    }

    public async Task<OpenOrderOutput> Execute(
        OpenOrderInput input,
        CancellationToken cancellationToken
    )
    {
        var customer = await _customerRepository.GetByIdAsync(
            input.CustomerId,
            cancellationToken
        );
        
        var salesConsultant = await _salesConsultantRepository.GetByIdAsync(
            input.SalesConsultantId,
            cancellationToken
        );

        if (customer is null || salesConsultant is null)
        {
            throw new Exception();
        }
        
        var order = Domain.Order.Order.Open(
            customer.Id,
            salesConsultant.Id
        );

        await _orderRepository.InsertAsync(order, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new OpenOrderOutput(order.Id.Format());
    }
}
