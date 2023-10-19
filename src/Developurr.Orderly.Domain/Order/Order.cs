using Developurr.Orderly.Domain.Customer.ValueObjects;
using Developurr.Orderly.Domain.Order.Entities;
using Developurr.Orderly.Domain.Order.Enums;
using Developurr.Orderly.Domain.Order.ValueObjects;
using Developurr.Orderly.Domain.SalesConsultant.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Shipping.ValueObjects;

namespace Developurr.Orderly.Domain.Order;

public sealed class Order : Entity<OrderId>, IAggregateRoot
{
    private readonly List<LineItem> _lineItems;
    private NaturezaDaOperacao _naturezaDaOperacao;
    private Status _status;
    public CustomerId CustomerId { get; }
    public SalesConsultantId SalesConsultantId { get; }
    public ShippingId? ShippingId { get; private set; }
    public Price OrderTotal { get; private set; }
    
    public ActiveStatus Active { get; private set; }

    private Order(
        OrderId orderId,
        NaturezaDaOperacao naturezaDaOperacao,
        CustomerId customerId,
        SalesConsultantId salesConsultantId,
        Price price,
        ActiveStatus active
    )
        : base(orderId)
    {
        _lineItems = new List<LineItem>();
        _naturezaDaOperacao = naturezaDaOperacao;
        _status = Status.Draft;
        CustomerId = customerId;
        SalesConsultantId = salesConsultantId;
        ShippingId = null;
        OrderTotal = price;
        Active = active;
    }
    
    public void Close()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
    }
    
    public static Order Open(CustomerId customerId, SalesConsultantId salesConsultantId)
    {
        var orderId = OrderId.Generate();
        var price = Price.Create(0);
        var active = ActiveStatus.Active;

        return new Order(orderId, NaturezaDaOperacao.Venda, customerId, salesConsultantId, price, active);
    }
}
