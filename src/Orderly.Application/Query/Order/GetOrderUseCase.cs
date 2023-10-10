using Orderly.Application.Command;
using Orderly.Domain.Order;

namespace Orderly.Application.Query.Order;

public class GetOrderUseCase : IUseCase<GetOrderInput, GetOrderOutput>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetOrderOutput> Execute(
        GetOrderInput input,
        CancellationToken cancellationToken
    )
    {
        var order = await _orderRepository.GetByIdAsync(input.OrderId, cancellationToken);

        return new GetOrderOutput(
            order.OrderTotal.Format()
        );
    }
}
