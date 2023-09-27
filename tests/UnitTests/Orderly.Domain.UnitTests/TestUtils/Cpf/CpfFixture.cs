using Bogus.Extensions.Brazil;

namespace Orderly.Domain.UnitTests.TestUtils.Cpf;

public sealed class CpfFixture : BaseFixture
{
    private static Domain.Common.ValueObjects.Cpf CreateValidCpf()
    {
        var cpf = Faker.Person.Cpf();

        return Domain.Common.ValueObjects.Cpf.Create(cpf);
    }

    public static Domain.Common.ValueObjects.Cpf CreateCpf(
        Domain.Common.ValueObjects.Cpf? cpf = null,
        string? value = null
    )
    {
        var lCpf = cpf ?? CreateValidCpf();

        return Domain.Common.ValueObjects.Cpf.Create(value ?? lCpf.Format());
    }

    public static string CreateInvalidCpf()
    {
        var cpf = Faker.Person.Cpf();
        var cpfArray = cpf.ToCharArray();

        for (var i = 1; i < 3; i++)
        {
            var digit = cpfArray[^i];
            var digitValue = int.Parse(digit.ToString());

            if (digitValue < 9)
                digitValue++;
            else
                digitValue = 0;

            cpfArray[^i] = digitValue.ToString()[0];
        }

        cpf = new string(cpfArray);

        return cpf;
    }

    public static string CreateWrongSizeCpf()
    {
        var cpf = Faker.Person.Cpf();

        cpf += Faker.Random.String2(Faker.Random.Int(5, 20), "0123456789");

        return cpf;
    }
}
