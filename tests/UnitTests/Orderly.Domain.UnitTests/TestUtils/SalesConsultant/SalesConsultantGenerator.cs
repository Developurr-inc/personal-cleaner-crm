using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.TestUtils.SalesConsultant;

public sealed class SalesConsultantGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateSalesConsultants()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { SalesConsultantFixture.CreateSalesConsultant() };
    }

    public static IEnumerable<object[]> CreateInvalidNames()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[] { StringFixture.CreateEmptyString() };
            yield return new object[] { SalesConsultantFixture.CreateShortName() };
            yield return new object[] { SalesConsultantFixture.CreateLongName() };
        }
    }
}
