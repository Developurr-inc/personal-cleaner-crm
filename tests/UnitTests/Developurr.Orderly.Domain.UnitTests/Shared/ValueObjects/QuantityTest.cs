using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class QuantityTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void GivenValidInput_WhenCreatingQuantity_ThenShouldInstantiateQuantity(
        int quantityValue
    )
    {
        // Act
        var quantity = Quantity.Create(quantityValue);

        // Assert
        Assert.NotNull(quantity);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingQuantity_ThenShouldHaveValidQuantity()
    {
        // Arrange
        const int quantityValue = 118;

        // Act
        var quantity = Quantity.Create(quantityValue);

        // Assert
        Assert.Equal(quantityValue, quantity.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    public void GivenNegativeQuantityValue_WhenCreatingQuantity_ThenShouldThrowEntityValidationExceptionWithMessage(
        int negativeQuantityValue
    )
    {
        // Arrange
        const string expectedMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => Quantity.Create(negativeQuantityValue));

        // Assert
        var domainValidationException = Assert.IsType<ValidationException>(exception);
        Assert.Contains(expectedMessage, domainValidationException.Message);
    }

    [Theory]
    [InlineData(3, 2, 5)]
    [InlineData(4, 3, 7)]
    public void GivenValidInput_WhenAddingQuantity_ThenShouldSumQuantities(
        int quantityValue1,
        int quantityValue2,
        int expectedQuantityValue
    )
    {
        // Arrange
        var quantity1 = Quantity.Create(quantityValue1);
        var quantity2 = Quantity.Create(quantityValue2);

        // Act
        var quantity = quantity1 + quantity2;

        // Assert
        Assert.Equal(expectedQuantityValue, quantity.Value);
    }

    [Theory]
    [InlineData(10, 2, 8)]
    [InlineData(38, 12, 26)]
    public void GivenValidInput_WhenSubtractingQuantity_ThenShouldSubtractQuantities(
        int quantityValue1,
        int quantityValue2,
        int expectedQuantityValue
    )
    {
        // Arrange
        var quantity1 = Quantity.Create(quantityValue1);
        var quantity2 = Quantity.Create(quantityValue2);

        // Act
        var quantity = quantity1 - quantity2;

        // Assert
        Assert.Equal(expectedQuantityValue, quantity.Value);
    }

    [Theory]
    [InlineData(10, 15)]
    [InlineData(20, 32)]
    [InlineData(13, 22)]
    public void GivenValidInput_WhenSubtractResultsNegativeQuantity_ThenShouldThrowEntityValidationExceptionWithMessage(
        int quantityValue1,
        int quantityValue2
    )
    {
        // Arrange
        var quantity1 = Quantity.Create(quantityValue1);
        var quantity2 = Quantity.Create(quantityValue2);
        const string expectedMessage =
            "There are validation errors. See ValidationMessages property for more details.";

        // Act
        var exception = Record.Exception(() => quantity1 - quantity2);

        // Assert
        var domainValidationException = Assert.IsType<ValidationException>(exception);
        Assert.Contains(expectedMessage, domainValidationException.Message);
    }
}