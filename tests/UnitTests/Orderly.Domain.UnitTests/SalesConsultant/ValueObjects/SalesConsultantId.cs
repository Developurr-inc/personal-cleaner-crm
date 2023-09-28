using Orderly.Domain.SalesConsultant.ValueObjects;

namespace Orderly.Domain.UnitTests.SalesConsultant.ValueObjects;

public sealed class SalesConsultantIdTest
{
    [Fact]
    public void GivenValidSalesConsultantId_WhenGeneratingSalesConsultantId_ThenShouldInstantiateSalesConsultantId()
    {
        // Act
        var salesConsultantId = SalesConsultantId.Generate();

        // Assert
        Assert.NotNull(salesConsultantId);
    }
}