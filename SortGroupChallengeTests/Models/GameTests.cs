using Moq;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallengeTests.Models;

public class GameTests
{
    [Fact]
    public void Create_ShouldThrowArgumentNullException_WhenDeckIsNull()
    {
        // Arrange
        int maxPlayerCount = 4;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Game.Create(null!, maxPlayerCount));
    }

    [Fact]
    public void Create_ShouldReturnGameInstance_WhenParametersAreValid()
    {
        // Arrange
        var deck = Deck.Create();
        int maxPlayerCount = 4;

        // Act
        var game = Game.Create(deck, maxPlayerCount);

        // Assert
        Assert.NotNull(game);
    }

    [Fact]
    public void Play_ShouldInvokeGameRoundServiceAndWinnerAnnouncer_WhenRoundsAreCompleted()
    {
        // Arrange
        var deck = Deck.Create();
        var game = Game.Create(deck, maxPlayerCount: 2);

        var mockGameRoundService = new Mock<IGameRoundService>();
        var mockRoundsCalculator = new Mock<IRoundsCalculator>();
        var mockWinnerAnnouncer = new Mock<IWinnerAnnouncer>();

        mockRoundsCalculator.SetupSequence(r => r.RoundsCompleted(It.IsAny<int>()))
            .Returns(true)
            .Returns(true);

        mockGameRoundService.SetupSequence(g => g.HasGameEndedAfterTurn(
            It.IsAny<Queue<Card>>(),
            It.IsAny<Player>()))
            .Returns(false)
            .Returns(true);

        // Act
        game.Play(
            mockGameRoundService.Object,
            mockRoundsCalculator.Object,
            mockWinnerAnnouncer.Object);

        // Assert
        mockRoundsCalculator.Verify(r => r.RoundsCompleted(It.IsAny<int>()), Times.Once());
        mockGameRoundService.Verify(g => g.HasGameEndedAfterTurn(
            It.IsAny<Queue<Card>>(),
            It.IsAny<Player>()), Times.Exactly(2));
        mockWinnerAnnouncer.Verify(w => w.AnnounceWinnerFrom(It.IsAny<IEnumerable<Player>>()), Times.Once());
    }
}
