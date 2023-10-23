using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.Shipping.ValueObjects;

namespace Developurr.Orderly.Domain.Shipping;

public sealed class Shipping : Entity<ShippingId>, IAggregateRoot
{
    // private readonly List<OrderId> _orders;
    public Cnpj Cnpj { get; }
    public NonEmptyText CorporateName { get; private set; }
    public NonEmptyText TaxId { get; private set; }
    public NonEmptyText TradeName { get; private set; }
    public NonEmptyText Segment { get; private set; }
    public ActiveStatus Active { get; private set; }

    private Shipping(
        ShippingId shippingId,
        Cnpj cnpj,
        NonEmptyText corporateName,
        NonEmptyText taxId,
        NonEmptyText tradeName,
        NonEmptyText segment,
        ActiveStatus active
    )
        : base(shippingId)
    {
        // _orders = new List<OrderId>();
        Cnpj = cnpj;
        CorporateName = corporateName;
        TaxId = taxId;
        TradeName = tradeName;
        Segment = segment;
        Active = active;
    }
    
    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
    }

    public static Shipping Create(
        string cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
    {
        var shippingId = ShippingId.Generate();
        var cnpjObj = Cnpj.Create(cnpj);
        var corporateNameObj = NonEmptyText.Create(corporateName);
        var taxIdObj = NonEmptyText.Create(taxId);
        var tradeNameObj = NonEmptyText.Create(tradeName);
        var segmentObj = NonEmptyText.Create(segment);
        var activeObj = ActiveStatus.Active;

        return new Shipping(
            shippingId,
            cnpjObj,
            corporateNameObj,
            taxIdObj,
            tradeNameObj,
            segmentObj,
            activeObj
        );
    }
}
