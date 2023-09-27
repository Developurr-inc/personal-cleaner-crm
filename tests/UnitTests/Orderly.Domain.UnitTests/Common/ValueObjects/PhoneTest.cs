using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Phone;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class PhoneTest
{
    [Theory]
    [MemberData(nameof(PhoneGenerator.CreatePhones), MemberType = typeof(PhoneGenerator))]
    public void GivenValidInput_WhenCreatingPhone_ThenShouldInstantiatePhone(Phone phone)
    {
        // Act
        var newPhone = PhoneFixture.CreatePhone(phone);

        // Assert
        PhoneAssertion.AssertPhone(phone, newPhone);
    }

    [Theory]
    [MemberData(nameof(PhoneGenerator.CreateInvalidPhones), MemberType = typeof(PhoneGenerator))]
    public void GivenInvalidPhone_WhenCreatingPhone_ThenShouldThrowEntityValidationException(
        string invalidPhone
    )
    {
        // Arrange
        void Action()
        {
            _ = PhoneFixture.CreatePhone(value: invalidPhone);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        PhoneAssertion.AssertException(exception!);
    }
    
}
