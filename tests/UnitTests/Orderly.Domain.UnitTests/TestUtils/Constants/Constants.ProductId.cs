using Orderly.Domain.SalesConsultant.ValueObjects;

namespace Orderly.Domain.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class ProductId
    {
        public static Domain.Product.ValueObjects.ProductId Id = Domain.Product.ValueObjects.ProductId.Generate();
    }
}