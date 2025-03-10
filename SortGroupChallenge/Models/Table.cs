﻿namespace SortGroupChallenge.Models;

public sealed record Table
{
    private readonly Cards _cards;

    public Table() => _cards = new Cards([]);

    public void AddCard(Card card)
    {
        ArgumentNullException.ThrowIfNull(card, nameof(card));

        _cards.Push(card);
    }

    public Card? TryPickupCard() => _cards.TryPeek(out Card? card) ? card : null;

    public void ClearCards() => _cards.Clear();

    public Cards GetCards() => _cards;

    public int CardCount() => _cards.Count;
}
