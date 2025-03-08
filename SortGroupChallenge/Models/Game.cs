using SortGroupChallenge.Services;

namespace SortGroupChallenge.Models;

public sealed class Game
{
    private readonly IEnumerable<Player> _players;
    private readonly Deck _deck;
    private readonly Queue<Card> _table;

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

        Play();
    }

    private void Play()
    {
        var snapService = StandardSnapService.Create(_table);
        var announcerService = StandWinnerAnnouncer.Create();

        while (AnyPlayerHasCardsLeft())
        {
            foreach (Player player in _players)
            {
                var gameRoundService = StandardGameRoundService.Create(_table, player);

                if (gameRoundService.HasGameEndedAfterTurn(snapService))
                {
                    announcerService.AnnounceWinnerFrom(_players);

                    return;
                }
            }
        }
    }

    private bool AnyPlayerHasCardsLeft() => _players.Any(p => p.HasCards());
}