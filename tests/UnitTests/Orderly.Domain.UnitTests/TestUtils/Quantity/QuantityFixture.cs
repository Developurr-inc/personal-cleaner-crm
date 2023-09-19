using Orderly.Domain.Quantity.Validators;

namespace Orderly.Domain.UnitTests.TestUtils.Quantity;

public class QuantityFixture : BaseFixture
{
    private static Domain.Quantity.ValueObjects.Quantity CreateValidQuantity()
    {
        var value = Faker.Random.Int(QuantityValidator.QuantityMin, QuantityValidator.QuantityMax);
        
        return Domain.Quantity.ValueObjects.Quantity.Create(value);
    }
    
    public static Domain.Quantity.ValueObjects.Quantity CreateQuantity(
        Domain.Quantity.ValueObjects.Quantity? quantity = null,
        int? value = null
    )
    {
        var lQuantity = quantity ?? CreateValidQuantity();

        return Domain.Quantity.ValueObjects.Quantity.Create(value ?? lQuantity.Value);
    }
    
    public static int CreateBellowMinQuantity()
    {
        return Faker.Random.Int(int.MinValue, QuantityValidator.QuantityMin);
    }
    
}