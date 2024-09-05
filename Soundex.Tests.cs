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
    public void GenerateSoundex_ShouldReturnEmptyString_WhenNameIsNullOrEmpty()
    {
        // Arrange & Act
        var resultEmpty = Soundex.GenerateSoundex("");
        var resultNull = Soundex.GenerateSoundex(null);

        // Assert
        Assert.Equal(string.Empty, resultEmpty);
        Assert.Equal(string.Empty, resultNull);
    }

    [Fact]
    public void GenerateSoundex_ShouldReturnSoundexCode_WhenValidNameIsProvided()
    {
        // Arrange
        var name1 = "Smith";
        var name2 = "Robert";
        var name3 = "Harris";

        // Act
        var result1 = Soundex.GenerateSoundex(name1);
        var result2 = Soundex.GenerateSoundex(name2);
        var result3 = Soundex.GenerateSoundex(name3);

        // Assert
        Assert.Equal("S530", result1); // Expected Soundex for "Smith"
        Assert.Equal("R163", result2); // Expected Soundex for "Robert"
        Assert.Equal("H620", result3); // Expected Soundex for "Harris"
    }

    [Fact]
    public void GenerateSoundex_ShouldPadWithZeros_WhenNameHasFewerThanFourDistinctCodes()
    {
        // Arrange
        var name = "Abe";

        // Act
        var result = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal("A100", result); // Should pad with zeros
    }

    [Fact]
    public void GenerateSoundex_ShouldHandleRepeatedCharactersCorrectly()
    {
        // Arrange
        var name = "Bobby";

        // Act
        var result = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal("B100", result); // Repeated characters should not be included multiple times
    }

    [Fact]
    public void GenerateSoundex_ShouldIgnoreVowelsAndNonMappedCharacters()
    {
        // Arrange
        var name = "Ashcroft";
        var name = "Cmmshksik";

        // Act
        var result = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal("A261", result); // Vowels and ignored characters (e.g., H) should be skipped
        Assert.Equal("C522", result);
    }

    [Fact]
    public void GenerateSoundex_ShouldHandleLongNamesByTruncatingToFourCharacters()
    {
        // Arrange
        var name = "Washington";

        // Act
        var result = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal("W252", result); // The result should be exactly 4 characters long
    }

    [Fact]
    public void GenerateSoundex_ShouldHandleSingleCharacterNames()
    {
        // Arrange
        var name = "Q";

        // Act
        var result = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal("Q000", result); // Single characters should be padded with zeros
    }
}
