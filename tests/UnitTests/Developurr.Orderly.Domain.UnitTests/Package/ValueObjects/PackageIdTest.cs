using Developurr.Orderly.Domain.Package.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Package.ValueObjects;

public sealed class PackageIdTest
{
    [Fact]
    public void GivenNothing_WhenGeneratingPackageId_ThenShouldInstantiatePackageId()
    {
        // Act
        var packageId = PackageId.Generate();

        // Assert
        Assert.NotNull(packageId);
    }
}
