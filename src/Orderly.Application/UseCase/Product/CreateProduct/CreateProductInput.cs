namespace Orderly.Application.UseCase.Product.CreateProduct;

public record CreateProductInput(
    string Code,
    string Name,
    string Packaging,
    decimal ExciseTax,
    decimal PriceValue
    );