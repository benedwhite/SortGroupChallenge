using Newtonsoft.Json.Linq;
using SortGroupChallenge.Models;
using System.Reflection.Metadata;

namespace SortGroupChallengeTests.Models;

public class PlayerTests
{
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Create_ShouldThrowArgumentException_WhenNameIsEmptyOrWhitespace(string name)
    {
        // Arrange
        Player sut = default!;

        // Act
        var exception = Record.Exception(() => sut = Player.Create(name!));
        
        // Assert
        Assert.Null(sut);
        Assert.IsType<ArgumentException>(exception);
        Assert.Equal(
            "The value cannot be an empty string or composed entirely of whitespace. (Parameter 'name')", 
            exception.Message);
    }

    [Fact]
    public void Create_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        // Arrange
        Player sut = default!;

        // Act
        var exception = Record.Exception(() => sut = Player.Create(null!));

        // Assert
        Assert.Null(sut);
        Assert.IsType<ArgumentNullException>(exception);
        Assert.Equal(
            "Value cannot be null. (Parameter 'name')",
            exception.Message);
    }
}
