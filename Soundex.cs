using System;
using System.Text;

public class Soundex
{
    private static readonly string VowelsAndIgnored = "AEIOUYHW";
    private static readonly string[] Codes = {
        "BFPV",  // 1
        "CGJKQSXZ",  // 2
        "DT",  // 3
        "L",  // 4
        "MN",  // 5
        "R"   // 6
    };

    public static string GenerateSoundex(string name)
    {
        if (IsInvalidName(name)) return string.Empty;

        StringBuilder soundex = BuildSoundexBase(name);

        ProcessRemainingLetters(name, soundex);

        PadWithZeros(soundex);

        return soundex.ToString();
    }

    private static bool IsInvalidName(string name) => string.IsNullOrEmpty(name);

    private static StringBuilder BuildSoundexBase(string name)
    {
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));  // Retain the first letter
        return soundex;
    }

    private static void ProcessRemainingLetters(string name, StringBuilder soundex)
    {
        int codeCount = 0;
        char prevCode = GetSoundexCode(name[0]);
        
        ProcessLettersInName(name, ref codeCount, ref prevCode, soundex);
    }

    private static void ProcessLettersInName(string name, ref int codeCount, ref char prevCode, StringBuilder soundex)
    {
        int length = name.Length;
        
        if (length <= 1 || codeCount >= 3) return;
        
        for (int i = 1; i < length && codeCount < 3; i++)
        {
            char currentChar = name[i];
            char currentCode = GetSoundexCode(currentChar);
            
            bool shouldProcess = !IsVowelOrIgnored(currentChar) && currentCode != prevCode && !IsHOrWSeparated(name, i);
            
            if (shouldProcess)
            {
                // Append soundex code and update variables
                soundex.Append(currentCode);
                prevCode = currentCode;
                codeCount++;
            }
        }
    }

    private static bool IsVowelOrIgnored(char c) => VowelsAndIgnored.Contains(c);

    private static void PadWithZeros(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
    }

    private static char GetSoundexCode(char c)
    {
        char upperChar = char.ToUpper(c);
        for (int i = 0; i < Codes.Length; i++)
        {
            if (Codes[i].Contains(upperChar))
            {
                return (char)('1' + i);
            }
        }
        return '0';
    }

    private static bool IsHOrWSeparated(string name, int index)
    {
        return index > 1 && (name[index - 1] == 'H' || name[index - 1] == 'W');
    }
}
