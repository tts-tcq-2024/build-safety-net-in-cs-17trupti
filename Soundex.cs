using System;
using System.Text;
using System.Collections.Generic;

public class Soundex
{
    private static readonly Dictionary<char, char> soundexMapping = new Dictionary<char, char>
    {
        { 'B', '1' }, { 'F', '1' }, { 'P', '1' }, { 'V', '1' },
        { 'C', '2' }, { 'G', '2' }, { 'J', '2' }, { 'K', '2' },
        { 'Q', '2' }, { 'S', '2' }, { 'X', '2' }, { 'Z', '2' },
        { 'D', '3' }, { 'T', '3' },
        { 'L', '4' },
        { 'M', '5' }, { 'N', '5' },
        { 'R', '6' }
    };

    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        string processedName = RemoveUnnecessaryCharacters(name);
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        char prevCode = GetSoundexCode(name[0]);

        for (int i = 1; i < processedName.Length && soundex.Length < 4; i++)
        {
            char code = GetSoundexCode(processedName[i]);
            if (code != '0' && code != prevCode)
            {
                soundex.Append(code);
                prevCode = code;
            }
        }

        return PadSoundexCode(soundex);
    }

    private static string RemoveUnnecessaryCharacters(string input)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in input)
        {
            if (!"AEIOUYHW".Contains(char.ToUpper(c)))
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return soundexMapping.ContainsKey(c) ? soundexMapping[c] : '0';
    }

    private static string PadSoundexCode(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
        return soundex.Length > 4 ? soundex.ToString().Substring(0, 4) : soundex.ToString();
    }
}
