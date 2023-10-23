namespace Developurr.Orderly.Domain.Product.ValueObjects;

public class Sku
{
    public readonly string Value;

    private Sku(string prefix, string categoryCode, string packageCode, string nameCode)
    {
        Value = $"{prefix}{categoryCode}{packageCode}{nameCode}";
    }

    public static Sku Generate(string prefix, string name, string category, string package)
    {
        if (prefix != "PRD" && prefix != "SER")
        {
            throw new ArgumentException("Value must be PRD or SER", nameof(prefix));
        }

        return new Sku(
            prefix,
            category.GetHashCode().ToString(),
            package.GetHashCode().ToString(),
            name.GetHashCode().ToString()
        );
    }
}
