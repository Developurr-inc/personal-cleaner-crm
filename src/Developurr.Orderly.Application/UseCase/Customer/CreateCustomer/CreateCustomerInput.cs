<<<<<<<< HEAD:src/Orderly.Application/Command/Customer/CreateCustomer/CreateCustomerInput.cs
namespace Orderly.Application.Command.Customer.CreateCustomer;
========
namespace Developurr.Orderly.Application.UseCase.Customer.CreateCustomer;
>>>>>>>> develop:src/Developurr.Orderly.Application/UseCase/Customer/CreateCustomer/CreateCustomerInput.cs

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
