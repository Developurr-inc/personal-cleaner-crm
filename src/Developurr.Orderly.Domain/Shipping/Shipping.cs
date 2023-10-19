using Developurr.Orderly.Domain.Order.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Shipping.Validators;
using Developurr.Orderly.Domain.Shipping.ValueObjects;

namespace Developurr.Orderly.Domain.Shipping;

public sealed class Shipping : Entity<ShippingId>, IAggregateRoot
{
    private readonly List<OrderId> _orders;
    public Cnpj Cnpj { get; }
    public NonEmptyText CorporateName { get; private set; }
    public NonEmptyText TaxId { get; private set; }
    public NonEmptyText TradeName { get; private set; }
    public NonEmptyText Segment { get; private set; }

    private Shipping(
        ShippingId shippingId,
        Cnpj cnpj,
        NonEmptyText corporateName,
        NonEmptyText taxId,
        NonEmptyText tradeName,
        NonEmptyText segment
    )
        : base(shippingId)
    {
        _orders = new List<OrderId>();
        Cnpj = cnpj;
        CorporateName = corporateName;
        TaxId = taxId;
        TradeName = tradeName;
        Segment = segment;
    }

    public static Shipping Create(
        string cnpjValue,
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
    {
        var shippingId = ShippingId.Generate();
        var cnpj = Cnpj.Create(cnpjValue);
        var corporateNameTrimmed = corporateName.Trim();
        var taxIdTrimmed = taxId.Trim();
        var tradeNameTrimmed = tradeName.Trim();
        var segmentTrimmed = segment.Trim();
        
        return new Shipping(
            shippingId,
            cnpj,
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed
        );
    }
}
