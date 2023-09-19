using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Product.Validators;
using Orderly.Domain.Product.ValueObjects;
using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Product;

public class Product : Entity<ProductId>, IAggregateRoot
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Packaging { get; private set; }
    public decimal ExciseTax { get; private set; }
    public Price Price { get; private set; }
    public DateTime CreatedAt { get; }

    private Product(
        string code,
        string name,
        string packaging,
        decimal exciseTax,
        Price price
    )
        : base(ProductId.Generate())
    {
        Code = code;
        Name = name;
        Packaging = packaging;
        ExciseTax = exciseTax;
        Price = price;
        CreatedAt = DateTime.Now;
    }

    public static Product Create(
        string code,
        string name,
        string packaging,
        decimal exciseTax,
        decimal price
    )
    {
        var nameTrimmed = name.Trim();
        var priceInst = Price.Create(price);
        
        Validate(nameTrimmed);
        
        return new Product(code, nameTrimmed, packaging, exciseTax, priceInst);
    }
    
    private static void Validate(string name)
    {
        var productValidator = new ProductValidator(name);
        productValidator.Validate();
    }
}