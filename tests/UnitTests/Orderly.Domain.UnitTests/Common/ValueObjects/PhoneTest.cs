using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Phone;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class PhoneTest
{
    [Theory]
    [MemberData(
        nameof(PhoneGenerator.CreatePhones),
        MemberType = typeof(PhoneGenerator)
    )]
    public void WhenCreatingPhone_GivenValidInput_ShouldInstantiatePhone(
        Phone phone
    )
    {
        // Arrange
        var phoneNumber = phone.Value;

        // Act
        var newPhone = Phone.Create(phoneNumber);

        // Assert
        PhoneAssertion.AssertPhone(phone, newPhone);
    }


    [Theory]
    [MemberData(
        nameof(PhoneGenerator.CreateInvalidPhones),
        MemberType = typeof(PhoneGenerator)
    )]
    public void WhenCreatingPhone_GivenInvalidInput_ShouldThrowException(
        string phoneValue
    )
    {
        // Arrange
        void Action()
        {
            _ = Phone.Create(phoneValue);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        PhoneAssertion.AssertPhoneException(exception!);
    }
}