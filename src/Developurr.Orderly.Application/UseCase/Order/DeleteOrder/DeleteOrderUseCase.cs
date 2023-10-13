using Developurr.Orderly.Domain.Order;

namespace Developurr.Orderly.Application.UseCase.Order.DeleteOrder;

public class DeleteOrderUseCase : IUseCase<DeleteOrderInput, DeleteOrderOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderUseCase(
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository
    )
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public async Task<DeleteOrderOutput> Execute(
        DeleteOrderInput input,
        CancellationToken cancellationToken
    )
    {
        var order = await _orderRepository.GetByIdAsync(
            input.OrderId,
            cancellationToken
        );

        await _orderRepository.RemoveAsync(order, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new DeleteOrderOutput(order.Id.Format());
    }
}