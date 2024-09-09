using System;
using System.Text;

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

        StringBuilder soundex = InitializeSoundex(name);

        ProcessLettersForSoundex(name, soundex);

        return PadSoundexCode(soundex);
    }

    private static StringBuilder InitializeSoundex(string name)
    {
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        return soundex;
    }

    private static void ProcessLettersForSoundex(string name, StringBuilder soundex)
    {
        char prevCode = GetSoundexCode(name[0]);

        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            TryAppendSoundexCode(name[i], soundex, ref prevCode);
        }
    }

    private static void TryAppendSoundexCode(char letter, StringBuilder soundex, ref char prevCode)
    {
        char code = GetSoundexCode(letter);
        if (ShouldAppendCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }

    private static bool ShouldAppendCode(char code, char prevCode)
    {
        return code != '0' && code != prevCode;
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
