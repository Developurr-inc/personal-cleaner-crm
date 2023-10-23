using Developurr.Orderly.Domain.Customer.ValueObjects;
using Developurr.Orderly.Domain.Order.Enums;
using Developurr.Orderly.Domain.Order.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Shipping.ValueObjects;
using Developurr.Orderly.Domain.Vendor.ValueObjects;

namespace Developurr.Orderly.Domain.Order;

public sealed class Order : Entity<OrderId>, IAggregateRoot
{
    // private readonly List<LineItem> _lineItems;
    private NaturezaDaOperacao _naturezaDaOperacao;

    public Status Status;
    public CustomerId CustomerId { get; }
    public VendorId VendorId { get; }
    public ShippingId? ShippingId { get; private set; }
    public Price OrderTotal { get; private set; }
    public ActiveStatus Active { get; private set; }

    private Order(
        OrderId orderId,
        NaturezaDaOperacao naturezaDaOperacao,
        CustomerId customerId,
        VendorId vendorId,
        Price price,
        ActiveStatus active
    )
        : base(orderId)
    {
        // _lineItems = new List<LineItem>();
        _naturezaDaOperacao = naturezaDaOperacao;
        Status = Status.Draft;
        CustomerId = customerId;
        VendorId = vendorId;
        ShippingId = null;
        OrderTotal = price;
        Active = active;
    }

    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
    }

    public void Close()
    {
        if (Status == Status.Draft)
            Status = Status.Closed;
    }

    public static Order Open(CustomerId customerId, VendorId vendorId)
    {
        var orderId = OrderId.Generate();
        var price = Price.Create(0);
        var active = ActiveStatus.Active;

        return new Order(orderId, NaturezaDaOperacao.Venda, customerId, vendorId, price, active);
    }
}
