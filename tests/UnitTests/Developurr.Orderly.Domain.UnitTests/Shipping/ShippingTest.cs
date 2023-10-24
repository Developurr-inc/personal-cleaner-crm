using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.Shared.ValueObjects;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Cnpj;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Shipping;

namespace Developurr.Orderly.Domain.UnitTests.Shipping;

public sealed class ShippingTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingShipping_ThenShouldInstantiateShipping()
    {
        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.NotNull(shipping);
    }

    [Fact]
    public void GivenValidCnpj_WhenCreatingShipping_ThenShouldHaveValidCnpj()
    {
        // Arrange
        const string cnpj = "59546515000134";
        const string expectedCnpj = "59.546.515/0001-34";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            cnpj,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedCnpj, shipping.Cnpj.ToString());
    }

    [Fact]
    public void GivenValidCorporateName_WhenCreatingShipping_ThenShouldHaveValidCorporateName()
    {
        // Arrange
        const string expectedCorporateName = "Sacolas MJ";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            expectedCorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedCorporateName, shipping.CorporateName);
    }

    [Fact]
    public void GivenValidTaxId_WhenCreatingShipping_ThenShouldHaveValidTaxId()
    {
        // Arrange
        const string expectedTaxId = "123456";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            expectedTaxId,
            Constants.Shipping.TradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedTaxId, shipping.TaxId);
    }

    [Fact]
    public void GivenValidTradeName_WhenCreatingShipping_ThenShouldHaveValidTradeName()
    {
        // Arrange
        const string expectedTradeName = "Sacolas MJ";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            expectedTradeName,
            Constants.Shipping.Segment
        );

        // Assert
        Assert.Equal(expectedTradeName, shipping.TradeName);
    }

    [Fact]
    public void GivenValidSegment_WhenCreatingShipping_ThenShouldHaveValidSegment()
    {
        // Arrange
        const string expectedSegment = "Embalagens";

        // Act
        var shipping = Developurr.Orderly.Domain.Shipping.Shipping.Create(
            Constants.Cnpj.CnpjValue,
            Constants.Shipping.CorporateName,
            Constants.Shipping.TaxId,
            Constants.Shipping.TradeName,
            expectedSegment
        );

        // Assert
        Assert.Equal(expectedSegment, shipping.Segment);
    }

    [Theory]
    [InlineData("", "Sacolas MJ", "123456", "Sacolas MJ", "Embalagens")]
    [InlineData("12.345.678/0001-00", "", "123456", "Sacolas MJ", "Embalagens")]
    [InlineData("12.345.678/0001-00", "Sacolas MJ", "", "Sacolas MJ", "Embalagens")]
    [InlineData("12.345.678/0001-00", "Sacolas MJ", "123456", "", "Embalagens")]
    [InlineData("12.345.678/0001-00", "Sacolas MJ", "123456", "Sacolas MJ", "")]
    public void GivenInvalidInput_WhenCreatingShipping_ThenShouldThrowEntityValidationExceptionWithMessage(
        string cnpj,
        string corporateName,
        string taxId,
        string tradeName,
        string segment
    )
    {
        // Arrange
        const string expectedErrorMessage = "There are validation errors.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Shipping.Shipping.Create(
                    cnpj,
                    corporateName,
                    taxId,
                    tradeName,
                    segment
                )
        );

        // Assert
        var eve = Assert.IsType<DomainValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Message);
    }
    
    [Fact]
    public void GivenValidInput_WhenCreatingShipping_ThenShouldHaveActiveStatusTrue()
    {
        // Arrange
        var cnpj = CnpjFixture.CreateCnpj();
        var corporateName = NonEmptyTextFixture.CreateNonEmptyText();
        var taxId = NonEmptyTextFixture.CreateNonEmptyText();
        var tradeName = NonEmptyTextFixture.CreateNonEmptyText();
        var segment = NonEmptyTextFixture.CreateNonEmptyText();

        // Act
        var shipping = Domain.Shipping.Shipping.Create(
            cnpj.ToString(),
            corporateName.ToString(),
            taxId.ToString(),
            tradeName.ToString(),
            segment.ToString()
        );

        // Assert
        Assert.True(shipping.Active.IsActive);
    }

    [Fact]
    public void GivenValidShipping_WhenDeactivatingShipping_ThenShouldBeInactive()
    {
        // Arrange
        var shipping = ShippingFixture.CreateShipping();

        // Act
        shipping.Deactivate();

        // Assert
        Assert.False(shipping.Active.IsActive);
    }
}
