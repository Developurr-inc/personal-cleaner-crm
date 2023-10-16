using Developurr.Orderly.Domain.Order;

namespace Developurr.Orderly.Application.Query.Order.GetOrder;

public class GetOrderUseCase : IQuery<GetOrderInput, GetOrderOutput>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetOrderOutput> Handle(GetOrderInput input, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(input.OrderId, cancellationToken);

        return new GetOrderOutput(order.OrderTotal.Format());
    }
}
