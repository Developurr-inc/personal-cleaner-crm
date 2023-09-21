namespace Orderly.Application.UseCase.Customer.CreateCustomer;

public record CreateCustomerInput(
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