using Developurr.Orderly.Domain.Exceptions;
using Developurr.Orderly.Domain.UnitTests.TestUtils.Category;
using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;

namespace Developurr.Orderly.Domain.UnitTests.Category;

public sealed class CategoryTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingCategory_ThenShouldInstantiateCategory()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();

        // Act
        var category = Domain.Category.Category.Create(name.ToString(), description.ToString());

        // Assert
        Assert.NotNull(category);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingCategory_ThenShouldHaveValidId()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();

        // Act
        var category = Domain.Category.Category.Create(name.ToString(), description.ToString());

        // Assert
        Assert.NotNull(category.Id);
    }

    [Fact]
    public void GivenValidName_WhenCreatingCategory_ThenShouldHaveValidName()
    {
        // Arrange
        var expectedName = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();

        // Act
        var category = Domain.Category.Category.Create(
            expectedName.ToString(),
            description.ToString()
        );

        // Assert
        Assert.Equal(expectedName.ToString(), category.Name.ToString());
    }

    [Fact]
    public void GivenValidDescription_WhenCreatingCategory_ThenShouldHaveValidDescription()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var expectedDescription = OptionalTextFixture.CreateOptionalText();

        // Act
        var category = Domain.Category.Category.Create(
            name.ToString(),
            expectedDescription.ToString()
        );

        // Assert
        Assert.Equal(expectedDescription.ToString(), category.Description.ToString());
    }

    [Fact]
    public void GivenInvalidInput_WhenCreatingCategory_ThenShouldThrowDomainValidationException()
    {
        // Arrange
        var description = OptionalTextFixture.CreateOptionalText();

        // Act
        var exception = Record.Exception(
            () => Domain.Category.Category.Create("", description.ToString())
        );

        // Assert
        Assert.IsType<ValidationException>(exception);
    }

    [Fact]
    public void GivenValidInput_WhenCreatingCategory_ThenShouldHaveActiveStatusTrue()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();

        // Act
        var category = Domain.Category.Category.Create(name.ToString(), description.ToString());

        // Assert
        Assert.True(category.Active.IsActive);
    }

    [Fact]
    public void GivenValidCategory_WhenDeactivatingCategory_ThenShouldBeInactive()
    {
        // Arrange
        var category = CategoryFixture.CreateCategory();

        // Act
        category.Deactivate();

        // Assert
        Assert.False(category.Active.IsActive);
    }
}