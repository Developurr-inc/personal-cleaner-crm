namespace Orderly.Domain.UnitTests.TestUtils.Cnpj;

public sealed class CnpjGenerator : BaseGenerator
{
    public static IEnumerable<object[]> CreateCnpjs()
    {
        for (var i = 0; i < Rounds; ++i)
            yield return new object[]
            {
                CnpjFixture.CreateCnpj()
            };
    }


    public static IEnumerable<object[]> CreateInvalidCnpjValues()
    {
        for (var i = 0; i < Rounds; ++i)
        {
            yield return new object[]
            {
                CnpjFixture.CreateWrongSizeCnpj()
            };

            yield return new object[]
            {
                CnpjFixture.CreateInvalidCnpjValue()
            };
        }
    }
}