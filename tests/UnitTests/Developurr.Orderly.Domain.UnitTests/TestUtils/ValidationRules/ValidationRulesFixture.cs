using Developurr.Orderly.Domain.Validation;
using Moq;

namespace Developurr.Orderly.Domain.UnitTests.TestUtils.ValidationRules;

public sealed class ValidationRulesFixture : BaseFixture
{
    public static Mock<IValidator> GetValidatorMock()
    {
        return new Mock<IValidator>();
    }
}
