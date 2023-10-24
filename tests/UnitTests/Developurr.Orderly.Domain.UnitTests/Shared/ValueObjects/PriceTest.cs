using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class PriceTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingPrice_ThenShouldInstantiatePrice()
    {
        // Arrange
        var p = PriceFixture.CreatePrice();

        // Act
        var price = Price.Create(p.Value);

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

    [Fact]
    public void GivenInvalidInput_WhenCreatingPrice_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const decimal invalidPrice = Constants.InvalidPrice.NegativePriceValue;
        // const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(() => Price.Create(invalidPrice));

        // Assert
        var eve = Assert.IsType<ArgumentException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.Message);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void GivenInvalidPrice_WhenCreatingPrice_ThenShouldThrowEntityValidationExceptionWithMessage(
        decimal invalidPrice
    )
    {
        // Arrange
        // const string expectedErrorMessage = "'Price' should be a positive decimal.";

        // Act
        var exception = Record.Exception(() => Price.Create(invalidPrice));

        // Assert
        var eve = Assert.IsType<ArgumentException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.Errors);
    }

    // [Fact]
    // public void GivenValidPrice_WhenCallToString_ShouldReturnFormattedPrice()
    // {
    //     // Arrange
    //     var price = PriceFixture.CreatePrice();
    //     const string expectedFormattedPrice = "R$ 10.99";
    //
    //     // Act
    //     var formattedPrice = price.ToString();
    //
    //     // Assert
    //     Assert.Equal(expectedFormattedPrice, formattedPrice);
    // }

    [Fact]
    public void GivenTwoPrices_WhenAddingThem_ShouldReturnSumOfPrices()
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
    public void GivenTwoPrices_WhenSubtractingThem_ShouldReturnSubtractOfPrices()
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
    public void GivenPrice_WhenMultiplyingByConstant_ShouldReturnMultipliedValue()
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
    public void GivenPrice_WhenDividingByConstant_ShouldReturnDividedValue()
    {
        // Arrange
        var price = PriceFixture.CreatePrice();
        var expectedPrice = price.Value / 3;

        // Act
        var divPrice = price / 3;

        // Assert
        Assert.Equal(expectedPrice, divPrice.Value);
    }
}