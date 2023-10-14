<<<<<<<< HEAD:src/Orderly.Application/Query/Customer/GetCustomerOutput.cs
namespace Orderly.Application.Query.Customer;
========
namespace Developurr.Orderly.Application.UseCase.Customer.GetCustomer;
>>>>>>>> develop:src/Developurr.Orderly.Application/UseCase/Customer/GetCustomer/GetCustomerOutput.cs

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
