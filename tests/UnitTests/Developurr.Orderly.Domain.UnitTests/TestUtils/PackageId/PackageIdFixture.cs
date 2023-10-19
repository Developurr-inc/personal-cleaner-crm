namespace Developurr.Orderly.Domain.UnitTests.TestUtils.PackageId;

public class PackageIdFixture
{
    public static Domain.Package.ValueObjects.PackageId GenerateId()
    {
        return Domain.Package.ValueObjects.PackageId.Generate();
    }
}
