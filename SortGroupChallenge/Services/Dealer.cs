﻿using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed record Dealer(Table Table, Players Players, Deck Deck) : IDealer
{
    public void Deal()
    {
        int cardsPerPlayer = Deck.Count / Players.Count();
        int playerIndex = 0;

        DealRemainingCards(cardsPerPlayer);

        foreach (Player player in Players)
        {
            var cards = new Cards(
                Deck.Cards
                .Skip(playerIndex * cardsPerPlayer)
                .Take(cardsPerPlayer));

            player.Pickup(cards);

            playerIndex++;
        }
    }

    private void DealRemainingCards(int cardsPerPlayer)
    {
        int remainder = Deck.Count % Players.Count();

        if (remainder <= 0)
        {
            return;
        }

        int cardsToSkip = cardsPerPlayer * Players.Count();

        Deck.Cards
            .Skip(cardsToSkip)
            .Take(remainder)
            .ToList()
            .ForEach(Table.AddCard);
    }
}
