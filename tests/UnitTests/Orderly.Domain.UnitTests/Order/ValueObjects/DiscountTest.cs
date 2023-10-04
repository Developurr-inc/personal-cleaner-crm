using Orderly.Domain.Exceptions;
using Orderly.Domain.Order.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Orderly.Domain.UnitTests.Order.ValueObjects;

public sealed class DiscountTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingDiscount_ThenShouldInstantiateDiscount()
    {
        // Act
        var discount = Discount.Create(
            Constants.Discount.DiscountValue
        );

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
        var exception = Record.Exception(
            () =>
                Discount.Create(
                    negativeDiscountValue
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenOverUpperLimitDiscountValue_WhenCreatingDiscount_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Arrange
        const decimal overUpperLimitDiscountValue = Constants.InvalidDiscount.OverUpperLimitDiscount;
        const string expectedErrorMessage = "'Discount' should be a decimal between 0 and 100.";
        
        // Act
        var exception = Record.Exception(
            () =>
                Discount.Create(
                    overUpperLimitDiscountValue
                )
        );
        
        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    //[Fact]
    //public void GivenValidDiscount_WhenCallFormat_ShouldReturnFormattedDiscount()
    //{
    //    // Arrange
    //    var discount = DiscountFixture.CreateDiscount();
    //    var expectedFormattedDiscount = $"20";
    //
    //    // Act
    //    var formattedDiscount = discount.Format();
    //
    //    // Assert
    //    Assert.Equal(expectedFormattedDiscount, formattedDiscount);
    //}
}