using Orderly.Domain.UnitTests.TestUtils.Shipping;

namespace Orderly.Domain.UnitTests.Shipping;

public sealed class ShippingTest
{
    [Theory]
    [MemberData(nameof(ShippingGenerator.CreateShippings), MemberType = typeof(ShippingGenerator))]
    public void GivenValidInputs_WhenCreatingShipping_ThenShouldInstantiateShipping(
        Domain.Shipping.Shipping shipping
    )
    {
        // Act
        var newShipping = ShippingFixture.CreateShipping(shipping);

        // Assert
        ShippingAssertion.AssertShipping(shipping, newShipping);
    }

    [Theory]
    [MemberData(
        nameof(ShippingGenerator.CreateInvalidCorporateNames),
        MemberType = typeof(ShippingGenerator)
    )]
    public void GivenInvalidCorporateName_WhenCreatingShipping_ThenShouldThrowException(
        string invalidCorporateName
    )
    {
        // Arrange
        void Action()
        {
            _ = ShippingFixture.CreateShipping(corporateName: invalidCorporateName);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        ShippingAssertion.AssertShippingException(exception!);
    }

    [Theory]
    [MemberData(
        nameof(ShippingGenerator.CreateInvalidTaxIds),
        MemberType = typeof(ShippingGenerator)
    )]
    public void GivenInvalidTaxId_WhenCreatingShipping_ThenShouldThrowException(string invalidTaxId)
    {
        // Arrange
        void Action()
        {
            _ = ShippingFixture.CreateShipping(taxId: invalidTaxId);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        ShippingAssertion.AssertShippingException(exception!);
    }

    [Theory]
    [MemberData(
        nameof(ShippingGenerator.CreateInvalidTradeNames),
        MemberType = typeof(ShippingGenerator)
    )]
    public void GivenInvalidTradeName_WhenCreatingShipping_ThenShouldThrowException(
        string invalidTradeName
    )
    {
        // Arrange
        void Action()
        {
            _ = ShippingFixture.CreateShipping(tradeName: invalidTradeName);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        ShippingAssertion.AssertShippingException(exception!);
    }

    [Theory]
    [MemberData(
        nameof(ShippingGenerator.CreateInvalidSegments),
        MemberType = typeof(ShippingGenerator)
    )]
    public void GivenInvalidSegment_WhenCreatingShipping_ThenShouldThrowException(
        string invalidSegment
    )
    {
        // Arrange
        void Action()
        {
            _ = ShippingFixture.CreateShipping(segment: invalidSegment);
        }

        // Act
        var exception = Record.Exception(Action);

        // Assert
        ShippingAssertion.AssertShippingException(exception!);
    }
}