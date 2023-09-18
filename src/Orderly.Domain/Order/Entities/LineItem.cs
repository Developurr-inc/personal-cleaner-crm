using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Order.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.Entities;

public class LineItem : Entity<LineItemId>
{
    // public ProductId ProductId { get; private set; }
    public Price UnitPrice { get; private set; }

    // public Discount Discount { get; private set; }
    // public Quantity Quantity { get; private set; }

    private LineItem(
        LineItemId lineItemId,
        // ProductId productId,
        Price unitPrice //,
    // Discount discount,
    // Quantity quantity
    )
        : base(lineItemId)
    {
        // ProductId = productId;
        UnitPrice = unitPrice;
        // Discount = discount;
        // Quantity = quantity;
    }

    public static LineItem Create(
        // ProductId productId,
        Price price //,
    // decimal discount,
    // int quantity
    )
    {
        var lineItemId = LineItemId.Generate();
        // var discount = discount.Create(discount);
        // var quantity = quantity.Create(quantity);

        return new LineItem(
            lineItemId, /*productId,*/
            price /*, discount, quantity*/
        );
    }
}
