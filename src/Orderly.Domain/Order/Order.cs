using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Customer.ValueObjects;
using Orderly.Domain.Order.Entities;
using Orderly.Domain.Order.Enums;
using Orderly.Domain.Order.ValueObjects;
using Orderly.Domain.SalesConsultant.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order;

public sealed class Order : Entity<OrderId>, IAggregateRoot
{
    private readonly List<LineItem> _lineItems;

    public CustomerId CustomerId { get; private set; }
    public SalesConsultantId SalesConsultantId { get; private set; }

    // public ShippingCompanyId? ShippingCompanyId { get; private set; }

    private TransactionNature _transactionNature;
    private Status _status;

    public Price OrderTotal { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Order(
        OrderId orderId,
        CustomerId customerId,
        SalesConsultantId salesConsultantId,
        TransactionNature transactionNature,
        Status status,
        Price price,
        DateTime createdAt
    )
        : base(orderId)
    {
        _lineItems = new();

        CustomerId = customerId;
        SalesConsultantId = salesConsultantId;
        // ShippingCompanyId = null;
        _transactionNature = transactionNature;
        _status = status;
        OrderTotal = price;
        CreatedAt = createdAt;
        UpdatedAt = createdAt;
    }

    public static Order Open(CustomerId customerId, SalesConsultantId salesConsultantId)
    {
        var orderId = OrderId.Generate();
        var status = Status.Draft;
        var transactionNature = TransactionNature.Venda;
        var price = Price.Create(default);
        var createdAt = DateTime.Now;

        return new Order(
            orderId,
            customerId,
            salesConsultantId,
            transactionNature,
            status,
            price,
            createdAt
        );
    }
}
