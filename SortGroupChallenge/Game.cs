using SortGroupChallenge.Factories;
using SortGroupChallenge.Models;
using SortGroupChallenge.Services;
using SortGroupChallenge.Services.Abstractions;
using SortGroupChallenge.Validators;

namespace SortGroupChallenge;

public sealed class Game
{
    private readonly Deck _deck;
    private readonly Players _players;
    private readonly Table _table;
    private readonly int _numberOfRounds;

    public Game(int numberOfPlayers, int numberOfRounds)
    {
        _deck = new Deck().Shuffle(new ShufflerService());
        _players = CreatePlayers(numberOfPlayers);
        _table = new Table();
        _numberOfRounds = numberOfRounds;
    }

    public void Play()
    {
        IGameRoundService gameRoundService = new GameRoundService();
        IRoundsManager roundsManager = new RoundsManager(_numberOfRounds);
        IWinnerAnnouncerService winnerAnnouncer = new WinnerAnnouncerService();

        DealCardsToPlayers();
        StartGame(gameRoundService, roundsManager, winnerAnnouncer);
    }

    private static Players CreatePlayers(int numberOfPlayers)
    {
        var playerFactory = new PlayerFactory(
            new PlayerValidator(numberOfPlayers));

        Players players = playerFactory.CreateMany(numberOfPlayers);

        return players;
    }

    private void DealCardsToPlayers()
    {
        var dealerService = new DealerService(_table, _players, _deck);

        dealerService.Deal();
    }

    private void StartGame(
        IGameRoundService gameRoundService,
        IRoundsManager roundsManager,
        IWinnerAnnouncerService winnerAnnouncer)
    {
        int round = 1;

        while (ShouldPlayRound(roundsManager, round))
        {
            foreach (Player player in _players)
            {
                if (!gameRoundService.HasGameEndedAfterTurn(_table, player))
                {
                    continue;
                }

                winnerAnnouncer.AnnounceWinnerFrom(_players);

                return;
            }

            round++;
        }

        winnerAnnouncer.AnnounceWinnerFrom(_players);
    }

    private bool ShouldPlayRound(IRoundsManager roundsCalculator, int round) =>
        _players.Any(p => p.HasCards())
        && roundsCalculator.IsWithinRoundLimit(round);
}
