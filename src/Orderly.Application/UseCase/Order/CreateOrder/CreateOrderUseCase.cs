using Orderly.Application.Command;
using Orderly.Domain.Customer;
using Orderly.Domain.Order;
using Orderly.Domain.SalesConsultant;
using Orderly.Domain.Shipping;

namespace Orderly.Application.UseCase.Order.CreateOrder;

public sealed class CreateOrderUseCase : IUseCase<CreateOrderInput, CreateOrderOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISalesConsultantRepository _salesConsultantRepository;
    private readonly IShippingRepository _shippingRepository;

    public CreateOrderUseCase(
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        ISalesConsultantRepository salesConsultantRepository,
        IShippingRepository shippingRepository
        
    )
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _salesConsultantRepository = salesConsultantRepository;
        _shippingRepository = shippingRepository;
    }

    public async Task<CreateOrderOutput> Execute(
        CreateOrderInput input,
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

        var order = Domain.Order.Order.Open(
            customer.Id,
            salesConsultant.Id
        );

        await _orderRepository.InsertAsync(order, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateOrderOutput(order.Id.Format());
    }
}
