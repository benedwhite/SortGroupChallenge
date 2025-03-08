﻿using SortGroupChallenge.Models;
using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class Shuffler : IShuffler
{
    private Shuffler() { }

    public static Shuffler Create() => new();

    public Cards Shuffle(Cards cards)
    {
        ArgumentNullException.ThrowIfNull(cards, nameof(cards));

        var shuffledCards = cards
            .OrderBy(_ => Guid.NewGuid())
            .ToList();

        var pack = Cards.Create(shuffledCards);

        return pack;
    }
}
