using Xunit;

public class SoundexTests
{
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

    [Fact]
    public void GenerateSoundex_ShouldReturnSoundexCode_WhenValidNameIsProvided()
    {
        var name1 = "Smith";
        var name2 = "Robert";
        var name3 = "Harris";

        var result1 = Soundex.GenerateSoundex(name1);
        var result2 = Soundex.GenerateSoundex(name2);
        var result3 = Soundex.GenerateSoundex(name3);

        Assert.Equal("S530", result1);
        Assert.Equal("R163", result2);
        Assert.Equal("H620", result3);
    }

    [Fact]
    public void GenerateSoundex_ShouldPadWithZeros_WhenNameHasFewerThanFourDistinctCodes()
    {
        var name = "Abe";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("A100", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldHandleRepeatedCharactersCorrectly()
    {
        var name = "Bobby";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("B100", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldIgnoreVowelsAndNonMappedCharacters()
    {
        var name = "Ashcroft";
        var name1 = "Cmmshksik";

        var result = Soundex.GenerateSoundex(name);
        var result1 = Soundex.GenerateSoundex(name1);

        Assert.Equal("A261", result);
        Assert.Equal("C522", result1);
    }

    [Fact]
    public void GenerateSoundex_ShouldHandleLongNamesByTruncatingToFourCharacters()
    {
        var name = "Washington";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("W252", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldHandleSingleCharacterNames()
    {
        var name = "Q";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("Q000", result);
    }
}
