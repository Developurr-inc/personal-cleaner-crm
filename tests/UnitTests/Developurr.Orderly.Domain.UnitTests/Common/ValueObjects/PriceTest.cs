using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Price;

namespace Developurr.Orderly.Domain.UnitTests.Common.ValueObjects;

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
}
