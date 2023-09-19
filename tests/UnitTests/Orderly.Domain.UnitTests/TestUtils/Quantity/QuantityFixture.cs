using Orderly.Domain.Order.Validators;

namespace Orderly.Domain.UnitTests.TestUtils.Quantity;

public sealed class QuantityFixture : BaseFixture
{
    private static Domain.Order.ValueObjects.Quantity CreateValidQuantity()
    {
        var value = Faker.Random.Int(QuantityValidator.QuantityMin, QuantityValidator.QuantityMax);
        
        return Domain.Order.ValueObjects.Quantity.Create(value);
    }
    
    public static Domain.Order.ValueObjects.Quantity CreateQuantity(
        Domain.Order.ValueObjects.Quantity? quantity = null,
        int? value = null
    )
    {
        var lQuantity = quantity ?? CreateValidQuantity();

        return Domain.Order.ValueObjects.Quantity.Create(value ?? lQuantity.Value);
    }
    
    public static int CreateBellowMinQuantity()
    {
        return Faker.Random.Int(int.MinValue, QuantityValidator.QuantityMin);
    }
    
}
