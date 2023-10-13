using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Constants;

namespace Developurr.Orderly.Domain.UnitTests.Product;

public sealed class ProductTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingProduct_ThenShouldInstantiateProduct()
    {
        // Act
        var product = Developurr.Orderly.Domain.Product.Product.Create(
            Constants.Product.Code,
            Constants.Product.Name,
            Constants.Product.Packaging,
            Constants.Product.ExciseTax,
            Constants.Product.PriceValue
        );

        // Assert
        Assert.NotNull(product);
    }
    
    [Fact]
    public void GivenValidName_WhenCreatingProduct_ThenShouldHaveValidName()
    {
        // Arrange
        const string expectedName = "Cleaning supply ABC";

        // Act
        var product = Developurr.Orderly.Domain.Product.Product.Create(
            Constants.Product.Code,
            expectedName,
            Constants.Product.Packaging,
            Constants.Product.ExciseTax,
            Constants.Product.PriceValue
        );

        // Assert
        Assert.Equal(expectedName, product.Name);
    }
    
    [Fact]
    public void GivenValidExciseTax_WhenCreatingProduct_ThenShouldHaveValidExciseTax()
    {
        // Arrange
        const decimal expectedExciseTax = 30;

        // Act
        var product = Developurr.Orderly.Domain.Product.Product.Create(
            Constants.Product.Code,
            Constants.Product.Name,
            Constants.Product.Packaging,
            expectedExciseTax,
            Constants.Product.PriceValue
        );

        // Assert
        Assert.Equal(expectedExciseTax, product.ExciseTax);
    }

    // [Theory]
    // [InlineData("", "ProductName", "Packaging", 20, 100)]
    // [InlineData("Code", "", "Packaging", 20, 100)]
    // [InlineData("Code", "ProductName", "", 20, 100)]
    // [InlineData("Code", "ProductName", "Packaging", -1, 100)]
    // public void GivenInvalidInput_WhenCreatingProduct_ThenShouldThrowEntityValidationExceptionWithMessage(
    //     string code,
    //     string name,
    //     string packaging,
    //     decimal exciseTax,
    //     decimal priceValue
    // )
    // {
    //     // Arrange
    //     const string expectedErrorMessage = "There are validation errors.";
    //
    //     // Act
    //     var exception = Record.Exception(
    //         () =>
    //             Domain.Product.Product.Create(
    //                 code,
    //                 name,
    //                 packaging,
    //                 exciseTax,
    //                 priceValue
    //             )
    //     );
    //
    //     // Assert
    //     var eve = Assert.IsType<EntityValidationException>(exception);
    //     Assert.Contains(expectedErrorMessage, eve.Message);
    // }

    public void GivenEmptyName_WhenCreatingProduct_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string emptyName = "";
        const string expectedErrorMessage = "'Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Product.Product.Create(
                    Constants.Product.Code,
                    emptyName,
                    Constants.Product.Packaging,
                    Constants.Product.ExciseTax,
                    Constants.Product.PriceValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenWhitespaceNAME_WhenCreatingProduct_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string whitespaceName = "             ";
        const string expectedErrorMessage = "'Name' is required.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Product.Product.Create(
                    Constants.Product.Code,
                    whitespaceName,
                    Constants.Product.Packaging,
                    Constants.Product.ExciseTax,
                    Constants.Product.PriceValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    } 
    
    [Fact]
    public void GivenShortName_WhenCreatingProduct_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string shortName = Constants.InvalidProduct.ShortName;
        const string expectedErrorMessage = "'Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Product.Product.Create(
                    Constants.Product.Code,
                    shortName,
                    Constants.Product.Packaging,
                    Constants.Product.ExciseTax,
                    Constants.Product.PriceValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    [Fact]
    public void GivenLongName_WhenCreatingProduct_ThenShouldThrowEntityValidationExceptionWithMessage()
    {
        // Assert
        const string longName = Constants.InvalidProduct.LongName;
        const string expectedErrorMessage = "'Name' should be between 5 and 255 characters.";

        // Act
        var exception = Record.Exception(
            () =>
                Developurr.Orderly.Domain.Product.Product.Create(
                    Constants.Product.Code,
                    longName,
                    Constants.Product.Packaging,
                    Constants.Product.ExciseTax,
                    Constants.Product.PriceValue
                )
        );

        // Assert
        var eve = Assert.IsType<EntityValidationException>(exception);
        Assert.Contains(expectedErrorMessage, eve.Errors);
    }
    
    // [Fact]
    // public void GivenInvalidNegativeExciseTax_WhenCreatingProduct_ThenShouldThrowEntityValidationExceptionWithMessage()
    // {
    //     // Assert
    //     const decimal invalidExciseTax = Constants.InvalidProduct.InvalidNegativeExciseTax;
    //     const string expectedErrorMessage = "'Excise Tax' should be a positive decimal.";
    //
    //     // Act
    //     var exception = Record.Exception(
    //         () =>
    //             Domain.Product.Product.Create(
    //                 Constants.Product.Code,
    //                 Constants.Product.Name,
    //                 Constants.Product.Packaging,
    //                 invalidExciseTax,
    //                 Constants.Product.PriceValue
    //             )
    //     );
    //
    //     // Assert
    //     var eve = Assert.IsType<EntityValidationException>(exception);
    //     Assert.Contains(expectedErrorMessage, eve.Errors);
    // }
    
    // [Fact]
    // public void GivenInvalidNullExciseTax_WhenCreatingProduct_ThenShouldThrowEntityValidationExceptionWithMessage()
    // {
    //     // Assert
    //     const decimal invalidExciseTax = Constants.InvalidProduct.InvalidNullExciseTax;
    //     const string expectedErrorMessage = "'Excise Tax' cannot be zero.";
    //
    //     // Act
    //     var exception = Record.Exception(
    //         () =>
    //             Domain.Product.Product.Create(
    //                 Constants.Product.Code,
    //                 Constants.Product.Name,
    //                 Constants.Product.Packaging,
    //                 invalidExciseTax,
    //                 Constants.Product.PriceValue
    //             )
    //     );
    //
    //     // Assert
    //     var eve = Assert.IsType<EntityValidationException>(exception);
    //     Assert.Contains(expectedErrorMessage, eve.Errors);
    // }
    
    [Fact]
    public void GivenUntrimmedName_WhenCreatingProduct_ThenShouldHaveTrimmedProduct()
    {
        // Arrange
        const string untrimmedName = "    Cleaning product abc       ";
        const string expectedName = "Cleaning product abc";

        // Act
        var product = Developurr.Orderly.Domain.Product.Product.Create(
            Constants.Product.Code,
            untrimmedName,
            Constants.Product.Packaging,
            Constants.Product.ExciseTax,
            Constants.Product.PriceValue
            
        );

        // Assert
        Assert.Equal(expectedName, product.Name);
    }
    
}