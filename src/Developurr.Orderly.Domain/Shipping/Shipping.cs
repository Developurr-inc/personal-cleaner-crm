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
    public string CorporateName { get; private set; }
    public string TaxId { get; private set; }
    public string TradeName { get; private set; }
    public string Segment { get; private set; }

    private Shipping(
        ShippingId shippingId,
        Cnpj cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment
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

        Validate(corporateNameTrimmed, taxIdTrimmed, tradeNameTrimmed, segmentTrimmed);

        return new Shipping(
            shippingId,
            cnpj,
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed
        );
    }

    private static void Validate(
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
    {
        var shippingValidator = new ShippingValidator(corporateName, taxId, tradeName, segment);
        shippingValidator.Validate();
    }
}
