using SortGroupChallenge.Services;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Models;

public sealed class Game
{
    private readonly Deck _deck;
    private readonly int _maxRoundCount;
    private readonly Queue<Card> _table;
    private readonly IEnumerable<Player> _players;

    private Game(Deck deck, IEnumerable<Player> players, int maxRoundCount)
    {
        _deck = deck;
        _players = players;
        _maxRoundCount = maxRoundCount;
        _table = [];
    }

    public static Game Create(Deck deck, int maxPlayerCount, int maxRoundCount)
    {
        ArgumentNullException.ThrowIfNull(deck, nameof(deck));

        Deck shuffledDeck = deck.Shuffle(new Shuffler());
        IEnumerable<Player> players = CreatePlayers(maxPlayerCount);

        return new(shuffledDeck, players, maxRoundCount);
    }

    public void Play()
    {
        Deal();

        Start(
            snapService: StandardSnapService.Create(_table),
            roundsCalculator: StandardRoundsCalculator.Create(_maxRoundCount),
            winnerAnnouncer: StandardWinnerAnnouncer.Create());
    }

    private static IEnumerable<Player> CreatePlayers(int maxPlayerCount)
    {
        var playerFactory = StandardPlayerFactory.Create(
            PlayerValidator.Create(maxPlayerCount));

        IEnumerable<Player> players = playerFactory
            .CreateMany(maxPlayerCount)
            .ToList();

        return players;
    }

    private void Deal()
    {
        var dealer = StandardDealer.Create(_table, _players, _deck);
        dealer.Deal();
    }

    private void Start(
        ISnapService snapService,
        IRoundsCalculator roundsCalculator,
        IWinnerAnnouncer winnerAnnouncer)
    {
        int round = 0;

        while (ShouldPlayRound(roundsCalculator, round))
        {
            round++;

            foreach (Player player in _players)
            {
                if (ProcessPlayerTurn(player, snapService))
                {
                    winnerAnnouncer.AnnounceWinnerFrom(_players);

                    return;
                }
            }
        }

        winnerAnnouncer.AnnounceWinnerFrom(_players);
    }

    private bool ProcessPlayerTurn(Player player, ISnapService snapService)
    {
        var gameRoundService = StandardGameRoundService.Create(_table, player);

        return gameRoundService.HasGameEndedAfterTurn(snapService);
    }

    private bool ShouldPlayRound(IRoundsCalculator roundsCalculator, int round)
        => _players.Any(p => p.HasCards()) && roundsCalculator.RoundsCompleted(round);
}