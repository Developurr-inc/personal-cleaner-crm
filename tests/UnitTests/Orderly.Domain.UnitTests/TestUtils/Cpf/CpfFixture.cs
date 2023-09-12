using Bogus.Extensions.Brazil;

namespace Orderly.Domain.UnitTests.TestUtils.Cpf;

public sealed class CpfFixture : BaseFixture
{
    public static Domain.Common.ValueObjects.Cpf CreateValidCpf()
    {
        var cpf = Faker.Person.Cpf();

        return Domain.Common.ValueObjects.Cpf.Create(cpf);
    }
    

    public static string CreateInvalidCpf()
    {
        var cpf = Faker.Person.Cpf();
        char[] cpfArray = cpf.ToCharArray();
        
        for (int i = 1; i < 3; i++)
        {
            char digit = cpfArray[cpfArray.Length - i];
            int digitValue = int.Parse(digit.ToString());

            if (digitValue < 9)
                digitValue++;
            else
                digitValue = 0;
            
            cpfArray[cpfArray.Length - i] = digitValue.ToString()[0];
        }
        
        cpf = new string(cpfArray);
        
        return cpf;
    }

    public static string CreateWrongSizeCpf()
    {
        var cpf = Faker.Person.Cpf();
        
        cpf +=  Faker.Random.String2(Faker.Random.Int(5, 20), "0123456789");
        
        return cpf;
    }
}