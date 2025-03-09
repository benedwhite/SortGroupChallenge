using SortGroupChallenge.Services;

namespace SortGroupChallengeTests.Services;

public class GameServiceTests
{
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void Create_GivenAValidNumberOfPlayersAndNumberOfRounds_ShouldReturnGameServiceWithCorrectSetupAndNotThrow(
        int numberOfPlayers)
    {
        // Arrange
        int numberOfRounds = 50;
        GameService? game = null;

        // Act
        Exception exception = Record.Exception(
            () => game = GameService.CreateGame(
                numberOfPlayers,
                numberOfRounds));

        // Assert
        Assert.NotNull(game);

        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    public void Create_GivenAnInvalidNumberOfPlayersAndNumberOfRounds_ShouldNotSetupAndThrow(
        int numberOfPlayers)
    {
        // Arrange
        int numberOfRounds = 50;
        GameService? game = null;

        // Act
        Exception exception = Record.Exception(
            () => game = GameService.CreateGame(
                numberOfPlayers,
                numberOfRounds));

        // Assert
        Assert.Null(game);

        Assert.IsType<InvalidOperationException>(exception);
        Assert.Equal(
            "Number of players must be between 2 and 4.", 
            exception.Message);
    }

    [Fact]
    public void Create_ShouldReturnGameServiceWithCorrectSetup()
    {
        // Arrange
        int numberOfPlayers = 2;
        int numberOfRounds = 50;

        // Act
        var game = GameService.CreateGame(numberOfPlayers, numberOfRounds);

        // Assert
        Assert.NotNull(game);
    }

    [Fact]
    public void Play_ShouldRunGameWithoutExceptions()
    {
        // Arrange
        int numberOfPlayers = 4;
        int numberOfRounds = 500;
        var game = GameService.CreateGame(numberOfPlayers, numberOfRounds);

        // Act
        Exception exception = Record.Exception(() => game.Play());

        // Assert
        Assert.Null(exception);
    }
}
