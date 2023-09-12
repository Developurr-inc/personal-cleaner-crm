using Bogus;

namespace Orderly.Domain.UnitTests.TestUtils;

public abstract class BaseFixture
{
    protected static readonly Faker Faker = new("pt_BR");
}