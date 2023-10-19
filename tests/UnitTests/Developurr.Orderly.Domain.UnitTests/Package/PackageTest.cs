using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;

namespace Developurr.Orderly.Domain.UnitTests.Package;

public class PackageTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingPackage_ThenShouldInstantiatePackage()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
    
        // Act
        var package = Domain.Package.Package.Create(name.Value);

        // Assert
        Assert.NotNull(package);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingPackage_ThenShouldHaveValidId()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
    
        // Act
        var package = Domain.Package.Package.Create(name.Value);
    
        // Assert
        Assert.NotNull(package.Id);
    }

    [Fact]
    public void GivenValidName_WhenCreatingPackage_ThenShouldHaveValidName()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
    
        // Act
        var package = Domain.Package.Package.Create(name.Value);
    
        // Assert
        Assert.Equal(name.Value, package.Name.Value);
    }
}
