using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;

namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Package;

public class PackageFixture
{
    public static Domain.Package.Package CreatePackage()
    {
        var name = NonEmptyTextFixture.CreateNonEmptyText();

        return Domain.Package.Package.Create(name.Value);
    }
}
