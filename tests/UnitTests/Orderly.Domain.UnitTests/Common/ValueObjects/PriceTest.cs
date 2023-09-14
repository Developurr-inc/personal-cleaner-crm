using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Price;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class PriceTest
{
    [Theory]
    [MemberData(nameof(PriceGenerator.CreatePrices), MemberType = typeof(PriceGenerator))]
    public void GivenValidInput_WhenCreatingPrice_ThenShouldInstantiatePrice(
        Price price
    )
    {
        // Act
        var newPrice = Price.Create(price.Value);

        // Assert
        PriceAssertion.AssertPrice(price, newPrice);
    }


    [Theory]
    [MemberData(nameof(PriceGenerator.CreateInvalidPrices), MemberType = typeof(PriceGenerator))]
    public void GivenInvalidPrice_WhenCreatingPrice_ThenShouldThrowEntityValidationException(
        decimal invalidPrice
    )
    {
        // Arrange
        void Action()
        {
            _ = Price.Create(invalidPrice);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        PriceAssertion.AssertPriceException(exception!);
    }
}