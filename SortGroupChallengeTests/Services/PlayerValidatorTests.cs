using SortGroupChallenge;
using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class PlayerValidatorTests
{
    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    public void IsValid_ShouldReturnTrue_WhenNumberOfPlayersIsWithinRange(int playerCount)
    {
        // Arrange
        var validator = PlayerValidator.Create(playerCount);

        // Act
        bool result = validator.IsValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValid_ShouldReturnFalse_WhenNumberOfPlayersIsBelowMin()
    {
        // Arrange
        int invalidNumberOfPlayers = Constants.Player.MinPlayerCount - 1;
        var validator = PlayerValidator.Create(invalidNumberOfPlayers);

        // Act
        bool result = validator.IsValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_ShouldReturnFalse_WhenNumberOfPlayersIsAboveMax()
    {
        // Arrange
        int invalidNumberOfPlayers = Constants.Player.MaxPlayerCount + 1;
        var validator = PlayerValidator.Create(invalidNumberOfPlayers);

        // Act
        bool result = validator.IsValid();

        // Assert
        Assert.False(result);
    }
}
