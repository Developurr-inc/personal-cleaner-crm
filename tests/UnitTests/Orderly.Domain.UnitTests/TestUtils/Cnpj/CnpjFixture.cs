using Bogus.Extensions.Brazil;

namespace Orderly.Domain.UnitTests.TestUtils.Cnpj;

public sealed class CnpjFixture : BaseFixture
{
    private static Domain.Common.ValueObjects.Cnpj CreateValidCnpj()
    {
        var cnpj = Faker.Company.Cnpj();

        return Domain.Common.ValueObjects.Cnpj.Create(cnpj);
    }
    
    
    public static Domain.Common.ValueObjects.Cnpj CreateCnpj(
        Domain.Common.ValueObjects.Cnpj? cnpj = null,
        string? value = null
    )
    {
        var lCnpj = cnpj ?? CreateValidCnpj();

        return Domain.Common.ValueObjects.Cnpj.Create(value ?? lCnpj.Value);
    }
    
    
    public static string CreateWrongSizeCnpj()
    {
        var cnpj = Faker.Company.Cnpj();

        cnpj +=  Faker.Random.String2(Faker.Random.Int(5, 20), "0123456789");

        return cnpj;
    }
    
    
    public static string CreateInvalidCnpjValue()
    {
        var cnpj = Faker.Company.Cnpj();
        char[] cnpjArray = cnpj.ToCharArray();

        for (int i = 1; i < 3; i++)
        {
            char digit = cnpjArray[cnpjArray.Length - i];
            int digitValue = int.Parse(digit.ToString());

            if (digitValue < 9)
                digitValue++;
            else
                digitValue = 0;

            cnpjArray[cnpjArray.Length - i] = digitValue.ToString()[0];
        }

        cnpj = new string(cnpjArray);

        return cnpj;
    }
}