using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Exceptions;
using Orderly.Domain.UnitTests.TestUtils.Constants;
using Orderly.Domain.UnitTests.TestUtils.Price;

namespace Orderly.Domain.UnitTests.Common.ValueObjects;

public sealed class PriceTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingPrice_ThenShouldInstantiatePrice()
    {
        // Act
        var price = Price.Create(Constants.Price.PriceValue);

        // Assert
        Assert.NotNull(price);
    }
    
    [Fact]
    public void GivenValidPrice_WhenCreatingPrice_ThenShouldHaveValidPrice()
    {
        // Arrange
        const string expectedPrice = "R$ 10,99";

        // Act
        var price = Price.Create(Constants.Price.PriceValue);
        
        // Assert 
        Assert.Equal(expectedPrice, price.Format());
    }

    [Fact]
    public void GivenInvalidInput_WhenCreatingPrice_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const decimal invalidPrice = Constants.InvalidPrice.NegativePriceValue;
        const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(
            () =>
                Price.Create(
                    invalidPrice
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    
    
    [Fact]
    public void GivenInvalidPrice_WhenCreatingPrice_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const decimal invalidPrice = Constants.InvalidPrice.NegativePriceValue;
        const string expectedErrorMessage = "'Price' should be a positive decimal.";

        // Act
        var exception = Record.Exception(
            () =>
                Price.Create(
                    invalidPrice
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenValidPrice_WhenCallFormat_ShouldReturnFormattedPrice()
    {
        // Arrange
        var price = PriceFixture.CreatePrice();
        var expectedFormattedPrice = $"R$ 10,99";

        // Act
        var formattedPrice = price.Format();

        // Assert
        Assert.Equal(expectedFormattedPrice, formattedPrice);
    }
    
}
