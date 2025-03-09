using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardDealer : IDealer
{
    private readonly Table _table;
    private readonly Players _players;
    private readonly Deck _deck;

    private StandardDealer(
        Table table,
        Players players, 
        Deck deck)
    {
        _table = table;
        _players = players;
        _deck = deck;
    }

    public static StandardDealer Create(
        Table table, 
        Players players, 
        Deck deck)
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

        DealRemainingCards(cardsPerPlayer);

        foreach (Player player in _players)
        {
            var cards = Cards
                .Create(_deck.Cards
                .Skip(playerIndex * cardsPerPlayer)
                .Take(cardsPerPlayer));

            player.Pickup(cards);

            playerIndex++;
        }
    }

    private void DealRemainingCards(int cardsPerPlayer)
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
            .ForEach(_table.AddCard);
    }
}
