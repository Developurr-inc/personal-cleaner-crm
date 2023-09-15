using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.Customer;

public sealed class CustomerGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateCustomers()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                CustomerFixture.CreateCustomer()
            };
    }


    public static IEnumerable<object[]> CreateInvalidCorporateNames()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                StringFixture.CreateEmptyString()
            };

            yield return new object[]
            {
                CustomerFixture.CreateShortCorporateName()
            };

            yield return new object[]
            {
                CustomerFixture.CreateLongCorporateName()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidTaxIds()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                StringFixture.CreateEmptyString()
            };

            yield return new object[]
            {
                CustomerFixture.CreateShortTaxId()
            };

            yield return new object[]
            {
                CustomerFixture.CreateLongTaxId()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidTradeNames()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                StringFixture.CreateEmptyString()
            };

            yield return new object[]
            {
                CustomerFixture.CreateShortTradeName()
            };

            yield return new object[]
            {
                CustomerFixture.CreateLongTradeName()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidSegments()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                StringFixture.CreateEmptyString()
            };

            yield return new object[]
            {
                CustomerFixture.CreateShortSegment()
            };

            yield return new object[]
            {
                CustomerFixture.CreateLongSegment()
            };
        }
    }


    public static IEnumerable<object[]> CreateInvalidObservations()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                CustomerFixture.CreateLongObservation()
            };
    }
}