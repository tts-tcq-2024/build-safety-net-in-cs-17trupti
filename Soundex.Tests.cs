using Xunit;

public class SoundexTests
{

    [Fact]
    public void GenerateSoundex_ShouldReturnEmptySoundexCode_WhenInputIsEmpty()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void GenerateSoundex_shouldReturnValidCode_WhenInputIsSingleNon_MappedLetter()
    {
        var name = "A";
        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("A000", result);
    }

    [Fact]
    public void GenerateSoundex_shouldReturnValidCode_WhenInputIsSingleMappedLetter()
    {
        var name = "B";
        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("B000", result);
    }

    [Fact]
    public void GenerateSoundex_shouldReturnValidCode_WhenInputWithAllLettersOfSameSoundexGroup()
    {
        var name = "BB";
        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("B000", result);
    }
    
    [Fact]
    public void GenerateSoundex_shouldReturnValidCode_WhenInputWithMultipleSoundexGroups()
    {
        var name1 = "Smith";
        var name2 = "Robert";
        var name3 = "Harris";
        var name4 = "Robert";

        var result1 = Soundex.GenerateSoundex(name1);
        var result2 = Soundex.GenerateSoundex(name2);
        var result3 = Soundex.GenerateSoundex(name3);
        var result4 = Soundex.GenerateSoundex(name4);

        Assert.Equal("S530", result1);
        Assert.Equal("R163", result2);
        Assert.Equal("H620", result3);
        Assert.Equal("R163", result4);
    }

    [Fact]
    public void GenerateSoundex_shouldReturnValidCode_WhenInputWithConsecutiveLettersFromSameSoundexGroups()
    {
        var name = "Rupert";
        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("R163", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldIgnoreVowelsAndNonMappedCharacters()
    {
        var name = "Ashcroft";
        var name1 = "Cmmshksik";

        var result = Soundex.GenerateSoundex(name);
        var result1 = Soundex.GenerateSoundex(name1);

        Assert.Equal("A261", result);
        Assert.Equal("C520", result1);
    }

    [Fact]
    public void GenerateSoundex_shouldReturnValidCode_WhenInputWithLowerCaseLetters()
    {
        var name = "rubin";
        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("R150", result);
    }

    [Fact]
    public void GenerateSoundex_shouldHandelInputWithCharactersOfSameSoundexGroupButSeperatedByVowel()
    {
        var name = "Bakes";
        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("B200", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldHandleLongNamesByTruncatingToFourCharacters()
    {
        var name = "Washington";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("W252", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldPadWithZeros_WhenNameHasFewerThanFourDistinctCodes()
    {
        var name = "Abe";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("A100", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldPadWithZeros_WhenInputWithLettersResultingWithSoundexLesserThanFour()
    {
        var name = "Omar";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("O560", result);
    }

    [Fact]
    public void GenerateSoundex_shouldReturnValidCode_WhenInputContainingRepeatedLettersWithSoundexCode()
    {
        var name = "Tennessee";

        var result = Soundex.GenerateSoundex(name);

        Assert.Equal("T520", result);
    }
    
}
