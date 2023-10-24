using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class PriceTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(0.0000001)]
    [InlineData(0.1)]
    public void GivenValidInput_WhenCreatingPrice_ThenShouldInstantiatePrice(decimal validPrice)
    {
        // Act
        var price = Price.Create(validPrice);

        // Assert
        Assert.NotNull(price);
    }

    [Fact]
    public void GivenValidPrice_WhenCreatingPrice_ThenShouldHaveValidPrice()
    {
        // Arrange
        var expectedPrice = PriceFixture.CreatePrice();

        // Act
        var price = Price.Create(expectedPrice.Value);

        // Assert
        Assert.Equal(expectedPrice.Value, price.Value);
    }

    [Theory]
    [InlineData(-0.0000001)]
    [InlineData(-0.1)]
    [InlineData(-123.45)]
    public void GivenInvalidInput_WhenCreatingPrice_ThenShouldThrowEntityValidationExceptionWithMessage(
        decimal invalidPrice
    )
    {
        // Arrange
        const string expectedMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => Price.Create(invalidPrice));

        // Assert
        var domainValidationException = Assert.IsType<ValidationException>(exception);
        Assert.Equal(expectedMessage, domainValidationException.Message);
    }

    [Fact]
    public void GivenTwoPrices_WhenAddingThem_ThenShouldReturnSumOfPrices()
    {
        // Arrange
        var price1 = PriceFixture.CreatePrice();
        var price2 = PriceFixture.CreatePrice();
        var expectedPrice = price1.Value + price2.Value;

        // Act
        var sumPrice = price1 + price2;

        // Assert
        Assert.Equal(expectedPrice, sumPrice.Value);
    }

    [Fact]
    public void GivenTwoPrices_WhenSubtractingThem_ThenShouldReturnSubtractOfPrices()
    {
        // Arrange
        var price1 = PriceFixture.CreatePrice();
        var price2 = PriceFixture.CreatePrice();
        var expectedPrice = price1.Value - price2.Value;

        // Act
        var subPrice = price1 - price2;

        // Assert
        Assert.Equal(expectedPrice, subPrice.Value);
    }

    [Fact]
    public void GivenPrice_WhenMultiplyingByConstant_ThenShouldReturnMultipliedValue()
    {
        // Arrange
        var price = PriceFixture.CreatePrice();
        var expectedPrice = price.Value * 5;

        // Act
        var mulPrice = price * 5;

        // Assert
        Assert.Equal(expectedPrice, mulPrice.Value);
    }

    [Fact]
    public void GivenPrice_WhenDividingByConstant_ThenShouldReturnDividedValue()
    {
        // Arrange
        var price = PriceFixture.CreatePrice();
        var expectedPrice = price.Value / 3;

        // Act
        var divPrice = price / 3;

        // Assert
        Assert.Equal(expectedPrice, divPrice.Value);
    }

    [Fact]
    public void GivenTwoPrices_WhenSubtractResultsNegativePrice_ThenShouldThrowEntityValidationExceptionWithMessaage()
    {
        // Arrange
        var price1 = Price.Create(10);
        var price2 = Price.Create(20);
        const string expectedMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => price1 - price2);

        // Assert
        var domainValidationException = Assert.IsType<ValidationException>(exception);
        Assert.Equal(expectedMessage, domainValidationException.Message);
    }

    [Fact]
    public void GivenTwoPrices_WhenDivisionResultsNegativePrice_ThenShouldThrowEntityValidationExceptionWithMessaage()
    {
        // Arrange
        var price1 = Price.Create(10);
        const string expectedMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => price1 / -9);

        // Assert
        var domainValidationException = Assert.IsType<ValidationException>(exception);
        Assert.Equal(expectedMessage, domainValidationException.Message);
    }
}