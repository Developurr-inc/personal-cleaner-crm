using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Email;
using Orderly.Domain.UnitTests.TestUtils.String;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class EmailTest
{
    [Theory]
    [MemberData(
        nameof(EmailGenerator.CreateEmails),
        MemberType = typeof(EmailGenerator)
    )]
    public void WhenCreatingEmail_GivenValidInput_ShouldInstantiateEmail(
        Email email
    )
    {
        // Arrange
        var emailAddress = email.Value;

        // Act
        var newEmail = Email.Create(emailAddress);

        // Assert
        EmailAssertion.AssertEmail(email, newEmail);
    }


    [Theory]
    [MemberData(
        nameof(EmailGenerator.CreateInvalidEmailAddresses),
        MemberType = typeof(EmailGenerator)
    )]
    public void WhenCreatingEmail_GivenInvalidEmail_ShouldThrowException(
        string emailAddress
    )
    {
        // Arrange
        void Action()
        {
            _ = Email.Create(emailAddress);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        EmailAssertion.AssertEmailException(exception!);
    }


    [Theory]
    [MemberData(
        nameof(StringGenerator.CreateInvalidStrings),
        MemberType = typeof(StringGenerator)
    )]
    public void WhenCreatingEmail_GivenInvalidString_ShouldThrowException(
        string str
    )
    {
        // Arrange
        void Action()
        {
            _ = Email.Create(str);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        EmailAssertion.AssertEmailException(exception!);
    }
}