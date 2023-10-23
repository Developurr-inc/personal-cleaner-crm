using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Package;

namespace Developurr.Orderly.Domain.UnitTests.Package;

public sealed class PackageTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingPackage_ThenShouldInstantiatePackage()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var package = Domain.Package.Package.Create(name.ToString());

        // Assert
        Assert.NotNull(package);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingPackage_ThenShouldHaveValidId()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var package = Domain.Package.Package.Create(name.ToString());

        // Assert
        Assert.NotNull(package.Id);
    }

    [Theory]
    [InlineData("")]
    public void GivenInvalidInput_WhenCreatingPackage_ThenShouldThrowEntityValidationExceptionWithMessage(
        string name
    )
    {
        // Arrange
        const string expectedErrorMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => Domain.Package.Package.Create(name));

        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, domainValidationException.Message);
    }

    [Theory]
    [InlineData("")]
    public void GivenInvalidInput_WhenCreatingPackage_ThenEntityValidationExceptionShouldContainMessage(
        string expectedMessage
    )
    {
        // Arrange
        var name = string.Empty;

        // Act
        var exception = Record.Exception(() => Domain.Package.Package.Create(name));

        // Assert
        var domainValidationException = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedMessage, domainValidationException.Message);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingPackage_ThenShouldHaveActiveStatusTrue()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var package = Domain.Package.Package.Create(name.ToString());

        // Assert
        Assert.True(package.Active.IsActive);
    }
    
    [Fact]
    public void GivenValidPackage_WhenDeactivatingPackage_ThenShouldBeInactive()
    {
        // Arrange
        var package = PackageFixture.CreatePackage();

        // Act
        package.Deactivate();

        // Assert
        Assert.False(package.Active.IsActive);
    }
}
