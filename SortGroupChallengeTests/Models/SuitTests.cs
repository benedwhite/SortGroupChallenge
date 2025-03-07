using SortGroupChallenge;
using SortGroupChallenge.Models;

namespace SortGroupChallengeTests.Models;

public class SuitTests
{
    [Theory]
    [InlineData(Constants.Suit.Hearts)]
    [InlineData(Constants.Suit.Diamonds)]
    [InlineData(Constants.Suit.Spades)]
    [InlineData(Constants.Suit.Clubs)]
    public void Create_GivenAValidSuitValue_ReturnsExpectedSuit(string suitValue)
    {
        // Arrange && Act
        Suit sut = Suit.Create(suitValue);

        // Assert
        Assert.Equal(suitValue, sut.ToString());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("abc")]
    [InlineData("123")]
    [InlineData("*$*(&&(*()")]
    public void Create_GivenAnInvalidSuitValue_ThrowsApplicationException(string? suitValue)
    {
        // Arrange
        Suit sut = default!;

        // Act
        var exception = Record.Exception(() => sut = Suit.Create(suitValue!));

        // Assert
        Assert.Null(sut);

        Assert.IsType<ApplicationException>(exception);
        Assert.Equal($"{suitValue} is not a valid value for suit", exception.Message);
    }
}
