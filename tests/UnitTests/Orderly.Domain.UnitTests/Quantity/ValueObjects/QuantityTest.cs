using Orderly.Domain.UnitTests.TestUtils;
using Orderly.Domain.UnitTests.TestUtils.Quantity;

namespace Orderly.Domain.UnitTests.Quantity.ValueObjects;

public class QuantityTest
{
    [Theory]
    [MemberData(nameof(QuantityGenerator.CreateQuantitys), MemberType = typeof(QuantityGenerator))]
    public void GivenValidInput_WhenCreatingQuantity_ThenShouldInstantiateQuantity(Domain.Quantity.ValueObjects.Quantity quantity)
    {
        // Act
        var newQuantity = QuantityFixture.CreateQuantity(quantity);

        // Assert
        QuantityAssertion.AssertQuantity(quantity, newQuantity);
    }
    
    [Theory]
    [MemberData(nameof(QuantityGenerator.CreateInvalidQuantitys), MemberType = typeof(QuantityGenerator))]
    public void GivenInvalidValue_WhenCreatingQuantity_ThenShouldThrowEntityValidationException(
        int invalidValue
    )
    {
        // Arrange
        void Action()
        {
            _ = QuantityFixture.CreateQuantity(value: invalidValue);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        BaseAssertion.AssertException(exception!);
    }
}