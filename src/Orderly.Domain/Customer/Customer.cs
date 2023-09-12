using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Customer.Validators;
using Orderly.Domain.Customer.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Customer;

public sealed class Customer : AggregateRoot<CustomerId>
{
    // public List<OrderId> Orders { get; private set; };
    // public SellerId Seller { get; private set; };

    public Cnpj Cnpj { get; private set; }
    public string CorporateName { get; private set; }
    public string TaxId { get; private set; }
    public string TradeName { get; private set; }
    public string Segment { get; private set; }

    public Email? BillingEmail { get; private set; }
    public Email NfeEmail { get; private set; }

    public Phone? Landline { get; private set; }
    public Phone? Mobile { get; private set; }

    public string Observation { get; private set; }


    private Customer(
        // SellerId sellerId,
        Cnpj cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        Email billingEmail,
        Email nfeEmail,
        Phone landline,
        Phone mobile,
        string observation
    )
    {
        // Orders = new();
        // Seller = sellerId;
        Cnpj = cnpj;
        CorporateName = corporateName;
        TaxId = taxId;
        TradeName = tradeName;
        Segment = segment;
        BillingEmail = billingEmail;
        NfeEmail = nfeEmail;
        Landline = landline;
        Mobile = mobile;
        Observation = observation;
    }
    
    
    // public void ChangeSeller(SellerId sellerId)
    // {
    //     SellerId = sellerId;
    // }
    
    
    public void UpdateCorporateName(string corporateName)
    {
        var corporateNameTrimmed = corporateName.Trim();

        Validate(
            corporateNameTrimmed,
            TaxId,
            TradeName,
            Segment,
            Observation
        );

        CorporateName = corporateNameTrimmed;
    }
    
    
    public void UpdateTaxId(string taxId)
    {
        var taxIdTrimmed = taxId.Trim();

        Validate(
            CorporateName,
            taxIdTrimmed,
            TradeName,
            Segment,
            Observation
        );

        TaxId = taxId;
    }
    
    
    public void UpdateTradeName(string tradeName)
    {
        var tradeNameTrimmed = tradeName.Trim();

        Validate(
            CorporateName,
            TaxId,
            tradeNameTrimmed,
            Segment,
            Observation
        );

        TradeName = tradeNameTrimmed;
    }
    
    
    public void UpdateSegment(string segment)
    {
        var segmentTrimmed = segment.Trim();

        Validate(
            CorporateName,
            TaxId,
            TradeName,
            segmentTrimmed,
            Observation
        );

        Segment = segmentTrimmed;
    }
    
    
    public void ChangeBillingEmail(Email billingEmail)
    {
        BillingEmail = billingEmail;
    }


    public void ChangeNfeEmail(Email nfeEmail)
    {
        NfeEmail = nfeEmail;
    }
    
    
    public void ChangeLandline(Phone landline)
    {
        Landline = landline;
    }
    
    
    public void ChangeMobile(Phone mobile)
    {
        Mobile = mobile;
    }


    public void UpdateObservation(string observation)
    {
        var observationTrimmed = observation.Trim();
        
        Validate(
            CorporateName,
            TaxId,
            TradeName,
            Segment,
            observationTrimmed
        );

        Observation = observationTrimmed;
    }


    public static Customer Create(
        // SellerId sellerId,
        Cnpj cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        Email billingEmail,
        Email nfeEmail,
        Phone landline,
        Phone mobile,
        string observation
    )
    {
        var corporateNameTrimmed = corporateName.Trim();
        var taxIdTrimmed = taxId.Trim();
        var tradeNameTrimmed = tradeName.Trim();
        var segmentTrimmed = segment.Trim();
        var observationTrimmed = observation.Trim();

        Validate(
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed,
            observationTrimmed
        );

        return new Customer(
            // sellerId,
            cnpj,
            corporateNameTrimmed,
            taxIdTrimmed,
            tradeNameTrimmed,
            segmentTrimmed,
            billingEmail,
            nfeEmail,
            landline,
            mobile,
            observationTrimmed
        );
    }
    
    
    private static void Validate(
        string corporateName,
        string taxId,
        string tradeName,
        string segment,
        string observation
    )
    {
        var customerValidator = new CustomerValidator(
            corporateName,
            taxId,
            tradeName,
            segment,
            observation
        );
        customerValidator.Validate();
    }
}