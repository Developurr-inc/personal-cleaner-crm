using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Shipping;

public class ShippingGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateShippings()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { ShippingFixture.CreateShipping() };
    }
    
    
    public static IEnumerable<object[]> CreateInvalidCorporateNames()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { StringFixture.CreateEmptyString() };
            yield return new object[] { ShippingFixture.CreateShortCorporateName() };
            yield return new object[] { ShippingFixture.CreateLongCorporateName() };
        }
    }
    
    
    public static IEnumerable<object[]> CreateInvalidTaxIds()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { StringFixture.CreateEmptyString() };
            yield return new object[] { ShippingFixture.CreateShortTaxId() };
            yield return new object[] { ShippingFixture.CreateLongTaxId() };
        }
    }
    
    
    public static IEnumerable<object[]> CreateInvalidTradeNames()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { StringFixture.CreateEmptyString() };
            yield return new object[] { ShippingFixture.CreateShortTradeName() };
            yield return new object[] { ShippingFixture.CreateLongTradeName() };
        }
    }
    
    
    public static IEnumerable<object[]> CreateInvalidSegments()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { StringFixture.CreateEmptyString() };
            yield return new object[] { ShippingFixture.CreateShortSegment() };
            yield return new object[] { ShippingFixture.CreateLongSegment() };
        }
    }
}