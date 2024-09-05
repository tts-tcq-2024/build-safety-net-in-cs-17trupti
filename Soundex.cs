using System;
using System.Text;
using System.Linq;

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
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        // Step 1: Retain the first letter
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);

        // Step 2: Encode remaining letters
        int codeCount = 0;
        for (int i = 1; i < name.Length && codeCount < 3; i++)
        {
            char currentChar = char.ToUpper(name[i]);
            if (VowelsAndIgnored.Contains(currentChar))
                continue;

            char currentCode = GetSoundexCode(currentChar);

            // Step 3: Handle adjacent same-code rule or H/W separator rule
            if (currentCode == prevCode || IsHOrWSeparated(name, i))
                continue;

            soundex.Append(currentCode);
            prevCode = currentCode;
            codeCount++;
        }

        // Step 4: Zero-pad the result to ensure a letter + 3 digits
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }

        return soundex.ToString();
    }

    private static char GetSoundexCode(char c)
    {
        for (int i = 0; i < Codes.Length; i++)
        {
            if (Codes[i].Contains(c))
                return (char)('1' + i);  // Return corresponding Soundex digit
        }
        return '0';
    }

    private static bool IsHOrWSeparated(string name, int index)
    {
        // Check if the current character is separated by 'H' or 'W'
        return index > 1 && (name[index - 1] == 'H' || name[index - 1] == 'W');
    }
}
