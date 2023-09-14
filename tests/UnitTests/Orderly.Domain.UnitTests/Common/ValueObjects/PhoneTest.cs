using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Phone;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class PhoneTest
{
    [Theory]
    [MemberData(nameof(PhoneGenerator.CreatePhones), MemberType = typeof(PhoneGenerator))]
    public void GivenValidInput_WhenCreatingPhone_ThenShouldInstantiatePhone(
        Phone phone
    )
    {
        // Act
        var newPhone = Phone.Create(phone.Value);

        // Assert
        PhoneAssertion.AssertPhone(phone, newPhone);
    }


    [Theory]
    [MemberData(nameof(PhoneGenerator.CreateInvalidPhones), MemberType = typeof(PhoneGenerator))]
    public void GivenInvalidInput_WhenCreatingPhone_ThenShouldThrowEntityValidationException(
        string invalidPhone
    )
    {
        // Arrange
        void Action()
        {
            _ = Phone.Create(invalidPhone);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        PhoneAssertion.AssertPhoneException(exception!);
    }
}