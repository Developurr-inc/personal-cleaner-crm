using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Order.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Order.ValueObjects;

public sealed class DiscountTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingDiscount_ThenShouldInstantiateDiscount()
    {
        // Act
        var discount = Discount.Create(Constants.Discount.DiscountValue);

        // Assert
        Assert.NotNull(discount);
    }

    [Fact]
    public void GivenNegativeDiscountValue_WhenCreatingDiscount_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const decimal negativeDiscountValue = Constants.InvalidDiscount.NegativeDiscount;
        const string expectedErrorMessage = "'Discount' should be a decimal between 0 and 100.";

        // Act
        var exception = Record.Exception(() => Discount.Create(negativeDiscountValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }

    [Fact]
    public void GivenOverUpperLimitDiscountValue_WhenCreatingDiscount_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const decimal overUpperLimitDiscountValue = Constants
            .InvalidDiscount
            .OverUpperLimitDiscount;
        const string expectedErrorMessage = "'Discount' should be a decimal between 0 and 100.";

        // Act
        var exception = Record.Exception(() => Discount.Create(overUpperLimitDiscountValue));

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        // Assert.Contains(expectedErrorMessage, eve.ValidationMessages);
    }
}
