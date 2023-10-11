namespace Orderly.Application.Query.Customer;

public record GetCustomerOutput(
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
