using Developurr.Orderly.Domain.Product.Validators;
using Developurr.Orderly.Domain.Product.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Product;

public sealed class Product : Entity<ProductId>, IAggregateRoot
{
    public string Code { get; }
    public string Name { get; private set; }
    public string Packaging { get; private set; }
    public decimal ExciseTax { get; private set; }
    public Price Price { get; private set; }

    private Product(
        ProductId productId,
        string code,
        string name,
        string packaging,
        decimal exciseTax,
        Price price
    )
        : base(productId)
    {
        Code = code;
        Name = name;
        Packaging = packaging;
        ExciseTax = exciseTax;
        Price = price;
    }

    public static Product Create(
        string code,
        string name,
        string packaging,
        decimal exciseTax,
        decimal priceValue
    )
    {
        var productId = ProductId.Generate();
        var nameTrimmed = name.Trim();
        var price = Price.Create(priceValue);

        Validate(nameTrimmed);

        return new Product(productId, code, nameTrimmed, packaging, exciseTax, price);
    }

    private static void Validate(string name)
    {
        var productValidator = new ProductValidator(name);
        productValidator.Validate();
    }
}
