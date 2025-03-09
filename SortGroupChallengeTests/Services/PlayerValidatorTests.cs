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
        var sut = new PlayerValidator(playerCount);

        // Act
        bool result = sut.IsValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValid_ShouldReturnFalse_WhenNumberOfPlayersIsBelowMin()
    {
        // Arrange
        int invalidNumberOfPlayers = Constants.Player.MinPlayerCount - 1;
        var sut = new PlayerValidator(invalidNumberOfPlayers);

        // Act
        bool result = sut.IsValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_ShouldReturnFalse_WhenNumberOfPlayersIsAboveMax()
    {
        // Arrange
        int invalidNumberOfPlayers = Constants.Player.MaxPlayerCount + 1;
        var sut = new PlayerValidator(invalidNumberOfPlayers);

        // Act
        bool result = sut.IsValid();

        // Assert
        Assert.False(result);
    }
}
