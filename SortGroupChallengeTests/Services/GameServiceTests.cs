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
        GameService? sut = null;

        // Act
        Exception exception = Record.Exception(
            () => sut = new GameService(
                numberOfPlayers,
                numberOfRounds));

        // Assert
        Assert.NotNull(sut);

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
        GameService? sut = null;

        // Act
        Exception exception = Record.Exception(
            () => sut = new GameService(
                numberOfPlayers,
                numberOfRounds));

        // Assert
        Assert.Null(sut);

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
        var sut = new GameService(numberOfPlayers, numberOfRounds);

        // Assert
        Assert.NotNull(sut);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 1)]
    [InlineData(2, 20)]
    [InlineData(3, 20)]
    [InlineData(4, 20)]
    [InlineData(2, 100)]
    [InlineData(3, 100)]
    [InlineData(4, 1000000)]
    public void Play_ShouldRunGameWithoutExceptions(
        int numberOfPlayers,
        int numberOfRounds)
    {
        // Arrange
        var sut = new GameService(numberOfPlayers, numberOfRounds);

        // Act
        Exception exception = Record.Exception(() => sut.Play());

        // Assert
        Assert.Null(exception);
    }
}
