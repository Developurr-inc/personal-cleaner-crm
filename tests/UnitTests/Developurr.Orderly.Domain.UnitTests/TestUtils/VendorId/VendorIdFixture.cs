namespace Developurr.Orderly.Domain.UnitTests.TestUtils.VendorId;

public class VendorIdFixture
{
    public static Domain.Vendor.ValueObjects.VendorId GenerateId()
    {
        return Domain.Vendor.ValueObjects.VendorId.Generate();
    }
}
