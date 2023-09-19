namespace Orderly.Domain.UnitTests.TestUtils.Quantity;

public class QuantityGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateQuantitys()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { QuantityFixture.CreateQuantity() };
    }

    public static IEnumerable<object[]> CreateInvalidQuantitys()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { QuantityFixture.CreateBellowMinQuantity() };
        }
    }
}