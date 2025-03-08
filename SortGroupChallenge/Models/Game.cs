using SortGroupChallenge.Services;

namespace SortGroupChallenge.Models;

public sealed class Game
{
    private readonly IEnumerable<Player> _players;
    private readonly Deck _deck;
    private readonly Queue<Card> _table;

    public event EventHandler<Player>? PlayerWon;

    private Game(IEnumerable<Player> players, Deck deck)
    {
        _players = players;
        _deck = deck;
        _table = [];
    }

    public static Game Create(IEnumerable<Player> players, Deck deck)
    {
        ArgumentNullException.ThrowIfNull(players, nameof(players));
        ArgumentNullException.ThrowIfNull(deck, nameof(deck));

        Deck shuffledDeck = deck.Shuffle(new Shuffler());

        return new(players, shuffledDeck);
    }

    public void Start()
    {
        var dealer = StandardDealer.Create(_players, _deck);

        dealer.Deal();

        var gameRoundService = StandardGameRoundService.Create(_table);

        Play(gameRoundService);
    }

    private void Play(StandardGameRoundService gameRoundService)
    {
        while (CanPlay())
        {
            foreach (Player player in _players)
            {
                if (gameRoundService.PlayerHasWon(player))
                {
                    PlayerWon?.Invoke(this, player);

                    return;
                }
            }
        }
    }

    private bool CanPlay() => _players.Any(p => p.HasCards());
}