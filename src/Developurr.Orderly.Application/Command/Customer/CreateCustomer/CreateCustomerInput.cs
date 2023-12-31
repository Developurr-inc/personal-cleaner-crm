namespace Developurr.Orderly.Application.Command.Customer.CreateCustomer;

public record CreateCustomerInput(
    string VendorId,
    string Cnpj,
    string CorporateName,
    string TaxId,
    string TradeName,
    string Segment,
    string? BillingEmail,
    string NfeEmail,
    string? Landline,
    string? Mobile,
    string Observation
);
