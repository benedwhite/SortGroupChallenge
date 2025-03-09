using SortGroupChallenge.Services;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Models;

public sealed class Game
{
    private readonly Deck _deck;
    private readonly Queue<Card> _table;
    private readonly IEnumerable<Player> _players;

    private Game(Deck deck, IEnumerable<Player> players)
    {
        _deck = deck;
        _players = players;
        _table = [];
    }

    public static Game Create(Deck deck, int maxPlayerCount)
    {
        ArgumentNullException.ThrowIfNull(deck, nameof(deck));

        Deck shuffledDeck = deck.Shuffle(new Shuffler());
        IEnumerable<Player> players = CreatePlayers(maxPlayerCount);

        return new(shuffledDeck, players);
    }

    public void Play(
        IGameRoundService gameRoundService,
        IRoundsCalculator roundsCalculator,
        IWinnerAnnouncer winnerAnnouncer)
    {
        ArgumentNullException.ThrowIfNull(gameRoundService, nameof(gameRoundService));
        ArgumentNullException.ThrowIfNull(roundsCalculator, nameof(roundsCalculator));
        ArgumentNullException.ThrowIfNull(winnerAnnouncer, nameof(winnerAnnouncer));

        Deal();
        Start(gameRoundService, roundsCalculator, winnerAnnouncer);
    }

    private static IEnumerable<Player> CreatePlayers(int maxPlayerCount)
    {
        var playerFactory = StandardPlayerFactory.Create(
            PlayerValidator.Create(maxPlayerCount));

        IEnumerable<Player> players = [.. playerFactory.CreateMany(maxPlayerCount)];

        return players;
    }

    private void Deal()
    {
        var dealer = StandardDealer.Create(_table, _players, _deck);
        dealer.Deal();
    }

    private void Start(
        IGameRoundService gameRoundService,
        IRoundsCalculator roundsCalculator,
        IWinnerAnnouncer winnerAnnouncer)
    {
        int round = 1;

        while (ShouldPlayRound(roundsCalculator, round))
        {
            round++;

            foreach (Player player in _players)
            {
                if (!gameRoundService.HasGameEndedAfterTurn(_table, player))
                {
                    continue;
                }

                winnerAnnouncer.AnnounceWinnerFrom(_players);

                return;
            }
        }

        winnerAnnouncer.AnnounceWinnerFrom(_players);
    }

    private bool ShouldPlayRound(IRoundsCalculator roundsCalculator, int round)
        => _players.Any(p => p.HasCards()) && roundsCalculator.IsWithinRoundLimit(round);
}