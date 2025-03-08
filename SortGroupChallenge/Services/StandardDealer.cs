using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardDealer : IDealer
{
    private readonly IEnumerable<Player> _players;
    private readonly Deck _deck;

    private StandardDealer(IEnumerable<Player> players, Deck deck)
    {
        _players = players;
        _deck = deck;
    }

    public static StandardDealer Create(IEnumerable<Player> players, Deck deck)
    {
        ArgumentNullException.ThrowIfNull(players, nameof(players));
        ArgumentNullException.ThrowIfNull(deck, nameof(deck));

        return new(players, deck);
    }

    public void Deal()
    {
        int cardsPerPlayer = _deck.Cards.Count() / _players.Count();
        int playerIndex = 0;

        foreach (var player in _players)
        {
            player.DealHand(
                _deck.Cards
                    .Skip(playerIndex * cardsPerPlayer)
                    .Take(cardsPerPlayer));

            playerIndex++;
        }
    }
}
