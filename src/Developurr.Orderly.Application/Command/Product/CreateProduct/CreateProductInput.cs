namespace Developurr.Orderly.Application.Command.Product.CreateProduct;

public record CreateProductInput(
    string Name,
    string Description,
    string CategoryId,
    string PackageId,
    decimal UnitPrice,
    decimal Imposto
);