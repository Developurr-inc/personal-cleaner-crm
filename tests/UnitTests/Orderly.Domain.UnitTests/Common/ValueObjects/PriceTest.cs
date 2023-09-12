using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Price;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class PriceTest
{
    [Theory]
    [MemberData(
        nameof(PriceGenerator.CreatePrices),
        MemberType = typeof(PriceGenerator)
    )]
    public void WhenCreatingPrice_GivenValidInput_ShouldInstantiatePrice(
        Price price
    )
    {
        // Arrange
        var value = price.Value;

        // Act
        var newPrice = Price.Create(value);

        // Assert
        PriceAssertion.AssertPrice(price, newPrice);
    }


    [Theory]
    [MemberData(
        nameof(PriceGenerator.CreateInvalidPrices),
        MemberType = typeof(PriceGenerator)
    )]
    public void WhenCreatingPrice_GivenInvalidInput_ShouldThrowException(
        decimal value
    )
    {
        // Arrange
        void Action()
        {
            _ = Price.Create(value);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        PriceAssertion.AssertPriceException(exception!);
    }
}