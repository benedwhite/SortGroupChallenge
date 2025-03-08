using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardDealer : IDealer
{
    private readonly Queue<Card> _table;
    private readonly IEnumerable<Player> _players;
    private readonly Deck _deck;

    private StandardDealer(
        Queue<Card> table,
        IEnumerable<Player> players, 
        Deck deck)
    {
        _table = table;
        _players = players;
        _deck = deck;
    }

    public static StandardDealer Create(
        Queue<Card> table, 
        IEnumerable<Player> 
        players, Deck deck)
    {
        ArgumentNullException.ThrowIfNull(table, nameof(table));
        ArgumentNullException.ThrowIfNull(players, nameof(players));
        ArgumentNullException.ThrowIfNull(deck, nameof(deck));

        return new(table, players, deck);
    }

    public void Deal()
    {
        int cardsPerPlayer = _deck.Count() / _players.Count();
        int playerIndex = 0;

        DealRemainderCards(cardsPerPlayer);

        foreach (var player in _players)
        {
            player.Pickup(
                _deck.Cards
                    .Skip(playerIndex * cardsPerPlayer)
                    .Take(cardsPerPlayer));

            playerIndex++;
        }
    }

    private void DealRemainderCards(int cardsPerPlayer)
    {
        int remainder = _deck.Count() % _players.Count();

        if (remainder <= 0)
        {
            return;
        }

        int cardsToSkip = cardsPerPlayer * _players.Count();

        _deck.Cards
            .Skip(cardsToSkip)
            .Take(remainder)
            .ToList()
            .ForEach(_table.Enqueue);
    }
}
