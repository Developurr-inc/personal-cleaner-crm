using Developurr.Orderly.Domain.UnitTests.TestUtils.NonEmptyText;
using Developurr.Orderly.Domain.UnitTests.TestUtils.OptionalText;

namespace Developurr.Orderly.Domain.UnitTests.Category;

public class CategoryTest
{
    [Fact]
    public void GivenValidInput_WhenCreatingCategory_ThenShouldInstantiateCategory()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var description = OptionalTextFixture.CreateOptionalText();
    
        // Act
        var category = Domain.Category.Category.Create(
            name.Value,
            description.Value
        );

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
        var category = Domain.Category.Category.Create(
            name.Value,
            description.Value
        );
    
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
            expectedName.Value,
            description.Value
        );
    
        // Assert
        Assert.Equal(expectedName.Value, category.Name.Value);
    }

    [Fact]
    public void GivenValidDescription_WhenCreatingCategory_ThenShouldHaveValidDescription()
    {
        // Arrange
        var name = NonEmptyTextFixture.CreateNonEmptyText();
        var expectedDescription = OptionalTextFixture.CreateOptionalText();
    
        // Act
        var category = Domain.Category.Category.Create(
            name.Value,
            expectedDescription.Value
        );
    
        // Assert
        Assert.Equal(expectedDescription.Value, category.Description.Value);
    }
}
