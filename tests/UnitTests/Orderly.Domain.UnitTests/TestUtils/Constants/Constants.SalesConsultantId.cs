using Orderly.Domain.SalesConsultant.ValueObjects;

namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class SalesConsultantId
    {
        public static Domain.SalesConsultant.ValueObjects.SalesConsultantId Id = Domain.SalesConsultant.ValueObjects.SalesConsultantId.Generate();
    }
}

