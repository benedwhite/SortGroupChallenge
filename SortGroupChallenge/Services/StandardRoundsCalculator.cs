﻿using SortGroupChallenge.Services.Interfaces;

namespace SortGroupChallenge.Services;

public sealed class StandardRoundsCalculator : IRoundsCalculator
{
    private readonly int _maxRounds;

    private StandardRoundsCalculator(int maxRounds) => _maxRounds = maxRounds;

    public static StandardRoundsCalculator Create(int maxRounds)
    {
        if (maxRounds <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxRounds), "Max rounds must be greater than 0.");
        }

        return new(maxRounds);
    }

    public bool IsWithinRoundLimit(int round)
    {
        if (round <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(round), "Round must be greater than 0.");
        }

        return round <= _maxRounds;
    }
}
