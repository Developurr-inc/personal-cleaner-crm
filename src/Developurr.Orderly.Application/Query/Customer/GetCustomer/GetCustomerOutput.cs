namespace Developurr.Orderly.Application.Query.Customer.GetCustomer;

public record GetCustomerOutput(
    string Id,
    string SalesConsultantId,
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