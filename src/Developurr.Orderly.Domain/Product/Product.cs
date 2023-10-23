using Developurr.Orderly.Domain.Category.ValueObjects;
using Developurr.Orderly.Domain.Package.ValueObjects;
using Developurr.Orderly.Domain.Product.ValueObjects;
using Developurr.Orderly.Domain.SeedWork;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.Product;

public sealed class Product : Entity<ProductId>, IAggregateRoot
{
    public readonly Sku Sku;
    public NonEmptyText Name { get; }
    public OptionalText Description { get; }
    public CategoryId CategoryId { get; }
    public PackageId PackageId { get; }
    public Price UnitPrice { get; }
    public Price Imposto { get; }
    public Quantity StockItems { get; private set; }
    public ActiveStatus Active { get; private set; }

    private Product(
        ProductId productId,
        Sku sku,
        NonEmptyText name,
        OptionalText description,
        CategoryId categoryId,
        PackageId packageId,
        Price unitPrice,
        Price imposto,
        Quantity stockItems,
        ActiveStatus active
    )
        : base(productId)
    {
        Sku = sku;
        Name = name;
        Description = description;
        CategoryId = categoryId;
        PackageId = packageId;
        UnitPrice = unitPrice;
        Imposto = imposto;
        StockItems = stockItems;
        Active = active;
    }

    public void Deactivate()
    {
        if (Active.IsActive)
            Active = ActiveStatus.Inactive;
    }

    public void AddStockItems(int quantity)
    {
        StockItems += Quantity.Create(quantity);
    }

    public void RemoveStockItems(int quantity)
    {
        StockItems -= Quantity.Create(quantity);
    }

    public static Product Create(
        string name,
        string description,
        CategoryId categoryId,
        PackageId packageId,
        decimal unitPrice,
        decimal imposto
    )
    {
        var productId = ProductId.Generate();
        var nameObj = NonEmptyText.Create(name);
        var descriptionObj = OptionalText.Create(description);
        var unitPriceObj = Price.Create(unitPrice);
        var impostoObj = Price.Create(imposto);
        var stockItemsObj = Quantity.Create(0);
        var activeObj = ActiveStatus.Active;
        var sku = Sku.Generate(
            "PRD",
            nameObj.ToString(),
            categoryId.ToString(),
            packageId.ToString()
        );

        return new Product(
            productId,
            sku,
            nameObj,
            descriptionObj,
            categoryId,
            packageId,
            unitPriceObj,
            impostoObj,
            stockItemsObj,
            activeObj
        );
    }
}
