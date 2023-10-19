using Developurr.Orderly.Domain.Vendor.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class VendorId
    {
        public static Developurr.Orderly.Domain.Vendor.ValueObjects.VendorId Id = Developurr.Orderly.Domain.Vendor.ValueObjects.VendorId.Generate();
    }
}

