using Developurr.Orderly.Domain.Order;

namespace Developurr.Orderly.Application.Command.Order.CloseOrder;

public class CloseOrderUseCase : ICommand<CloseOrderInput, CloseOrderOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;

    public CloseOrderUseCase(
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository
    )
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public async Task<CloseOrderOutput> Handle(CloseOrderInput input, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(
            input.OrderId,
            cancellationToken
        );

        await _orderRepository.RemoveAsync(order, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new CloseOrderOutput(order.Id.Format());
    }
}
