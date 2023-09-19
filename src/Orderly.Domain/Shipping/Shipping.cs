using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.SeedWork;
using Orderly.Domain.Shipping.Validators;
using Orderly.Domain.Shipping.ValueObjects;

namespace Orderly.Domain.Shipping;

public class Shipping : Entity<ShippingId>, IAggregateRoot
{
    public Cnpj Cnpj { get; private set; }
    public string CorporateName { get; private set; }
    public string TaxId { get; private set; }
    public string TradeName { get; private set; }
    public string Segment { get; private set; }

    public DateTime CreatedAt { get; }

    private Shipping(
        Cnpj cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
        : base(ShippingId.Generate())
    {
        Cnpj = cnpj;
        CorporateName = corporateName;
        TaxId = taxId;
        TradeName = tradeName;
        Segment = segment;
        CreatedAt = DateTime.Now;
    }
    
    
    public static Shipping Create(
        Cnpj cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
    {
        var corporateNameTrimmed = corporateName.Trim();
        var taxIdTrimmed = taxId.Trim();
        var tradeNameTrimmed = tradeName.Trim();
        var segmentTrimmed = segment.Trim();

        Validate(
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed
        );

        return new Shipping(
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
        var shippingValidator = new ShippingValidator(
            corporateName,
            taxId,
            tradeName,
            segment
        );
        shippingValidator.Validate();
    }
}
