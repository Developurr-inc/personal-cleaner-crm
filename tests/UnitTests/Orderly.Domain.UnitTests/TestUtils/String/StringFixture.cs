namespace Orderly.Domain.UnitTests.TestUtils.String;

public sealed class StringFixture : BaseFixture
{
    public static string CreateEmptyString()
    {
        return "";
    }


    public static string CreateWhiteSpaceString()
    {
        return Faker.Random.String2(1, 100, " ");
    }


    public static string CreateString(int min = 1, int max = 100)
    {
        return Faker.Random.String2(min, max);
    }
}