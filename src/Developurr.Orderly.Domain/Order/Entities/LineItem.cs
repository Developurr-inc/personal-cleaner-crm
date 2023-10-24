using Developurr.Orderly.Domain.Order.ValueObjects;
using Developurr.Orderly.Domain.Product.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Order.Entities;

public partial class LineItem : Entity<LineItemId>
{
    public ProductId ProductId { get; private set; }
    public Price UnitPrice { get; private set; }
    public Discount Discount { get; private set; }
    public Quantity Quantity { get; private set; }

    private LineItem(
        LineItemId lineItemId,
        ProductId productId,
        Price unitPrice,
        Discount discount,
        Quantity quantity
    )
        : base(lineItemId)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Discount = discount;
        Quantity = quantity;
    }

    public static LineItem Create(
        ProductId productId,
        Price price,
        decimal discountValue,
        int quantityValue
    )
    {
        var lineItemId = LineItemId.Generate();
        var discount = Discount.Create(discountValue);
        var quantity = Quantity.Create(quantityValue);

        return new LineItem(lineItemId, productId, price, discount, quantity);
    }
}
