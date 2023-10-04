namespace Orderly.Application.UseCase.Shipping.CreateShipping;

public record CreateShippingInput
(
    string Cnpj,
    string CorporateName,
    string TaxId,
    string TradeName,
    string Segment
);