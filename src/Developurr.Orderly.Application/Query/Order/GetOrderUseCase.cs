using Developurr.Orderly.Application.Command;
using Developurr.Orderly.Domain.Order;

namespace Developurr.Orderly.Application.Query.Order;

public class GetOrderUseCase : IQuery<UseCase.Order.GetOrder.GetOrderInput, UseCase.Order.GetOrder.GetOrderOutput>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<UseCase.Order.GetOrder.GetOrderOutput> Handle(
        UseCase.Order.GetOrder.GetOrderInput input,
        CancellationToken cancellationToken
    )
    {
        var order = await _orderRepository.GetByIdAsync(input.OrderId, cancellationToken);

        return new UseCase.Order.GetOrder.GetOrderOutput(
            order.OrderTotal.Format()
        );
    }
}
