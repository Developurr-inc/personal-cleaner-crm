using Orderly.Domain.Order.ValueObjects;
using Orderly.Domain.UnitTests.TestUtils.Discount;

namespace Orderly.Domain.UnitTests.Order.ValueObjects;

public sealed class DiscountTest
{
    [Theory]
    [MemberData(nameof(DiscountGenerator.CreateDiscounts), MemberType = typeof(DiscountGenerator))]
    public void GivenValidInput_WhenCreatingDiscount_ThenShouldInstantiateDiscount(Discount discount)
    {
        // Act
        var newDiscount = DiscountFixture.CreateDiscount(discount);

        // Assert
        DiscountAssertion.AssertDiscount(discount, newDiscount);
    }
    
    [Theory]
    [MemberData(nameof(DiscountGenerator.CreateInvalidDiscounts), MemberType = typeof(DiscountGenerator))]
    public void GivenInvalidValue_WhenCreatingDiscount_ThenShouldThrowEntityValidationException(
        decimal invalidValue
    )
    {
        // Arrange
        void Action()
        {
            _ = DiscountFixture.CreateDiscount(value: invalidValue);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        DiscountAssertion.AssertDiscountException(exception!);
    }
}