namespace Orderly.Domain.UnitTests.TestUtils.String;

public sealed class StringGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateStrings()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { StringFixture.CreateString() };
    }

    public static IEnumerable<object[]> CreateInvalidStrings()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[] { StringFixture.CreateWhiteSpaceString() };

        yield return new object[] { StringFixture.CreateEmptyString() };
    }
}
