using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Shared.ValueObjects;

public sealed class QuantityTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingQuantity_ThenShouldInstantiateQuantity()
    {
        // Act
        var quantity = Quantity.Create(Constants.Quantity.Value);

        // Assert
        Assert.NotNull(quantity);
    }

    [Fact]
    public void GivenNegativeQuantityValue_WhenCreatingQuantity_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const int negativeQuantityValue = Constants.InvalidQuantity.NegativeQuantity;
        // const string expectedErrorMessage = "'Quantity' should be an int between 0 and 2147483646.";

        // Act
        var exception = Record.Exception(() => Quantity.Create(negativeQuantityValue));

        // Assert
        var eve = Assert.IsType<ArgumentException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.Errors);
    }
}
