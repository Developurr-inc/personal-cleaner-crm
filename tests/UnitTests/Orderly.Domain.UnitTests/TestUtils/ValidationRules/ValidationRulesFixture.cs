using Orderly.Domain.Validation;
using Moq;

namespace Orderly.Domain.UnitTests.TestUtils.ValidationRules;

public sealed class ValidationRulesFixture : BaseFixture
{
    public static Mock<IValidator> GetValidatorMock()
    {
        return new Mock<IValidator>();
    }
}
