using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class GameService : IGameService
{
    private readonly Deck _deck;
    private readonly Players _players;
    private readonly Table _table;
    private readonly int _numberOfRounds;

    private GameService(Deck deck, Players players, int numberOfRounds)
    {
        _deck = deck;
        _players = players;
        _table = Table.Create();
        _numberOfRounds = numberOfRounds;
    }

    public static GameService CreateGame(int numberOfPlayers, int numberOfRounds)
    {
        IShuffler shuffler = Shuffler.Create();

        Deck shuffledDeck = Deck
            .Create()
            .Shuffle(shuffler);

        Players players = CreatePlayers(numberOfPlayers);

        return new(shuffledDeck, players, numberOfRounds);
    }

    public void Play()
    {
        IGameRoundService gameRoundService = StandardGameRoundService.Create();
        IRoundsCalculator roundsCalculator = StandardRoundsCalculator.Create(_numberOfRounds);
        IWinnerAnnouncer winnerAnnouncer = StandardWinnerAnnouncer.Create();

        DealCardsToPlayers();
        StartGame(gameRoundService, roundsCalculator, winnerAnnouncer);
    }

    private static Players CreatePlayers(int maxPlayerCount)
    {
        var playerFactory = StandardPlayerFactory.Create(
            PlayerValidator.Create(maxPlayerCount));

        Players players = playerFactory.CreateMany(maxPlayerCount);

        return players;
    }

    private void DealCardsToPlayers()
    {
        var dealer = StandardDealer.Create(_table, _players, _deck);

        dealer.Deal();
    }

    private void StartGame(
        IGameRoundService gameRoundService,
        IRoundsCalculator roundsCalculator,
        IWinnerAnnouncer winnerAnnouncer)
    {
        int round = 1;

        while (ShouldPlayRound(roundsCalculator, round))
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

    private bool ShouldPlayRound(IRoundsCalculator roundsCalculator, int round)
        => _players.Any(p => p.HasCards()) && roundsCalculator.IsWithinRoundLimit(round);
}
