using System.Text;

namespace Interview.Samples.Application.Strings;

public static class PalindromService
{
    public static int CalculateLongestPalindrome(string input)
    {
        Dictionary<char, int> charCount = [];

        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        var maxLength = 0;
        var anyOddFound = false;
        foreach (int count in charCount.Values)
        {
            if (count % 2 == 0)
            {
                maxLength += count;
            }
            else
            {
                maxLength += count - 1;
                anyOddFound = true;
            }
        }

        if (anyOddFound)
        {
            maxLength++;
        }

        return maxLength;
    }

    public static string GetPalindrome(string input)
    {
        Dictionary<char, int> charCount = [];
        StringBuilder leftPart = new StringBuilder();
        StringBuilder rightPart = new StringBuilder();
        char? middleChar = null;

        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        foreach (var pair in charCount)
        {
            var count = pair.Value;
            var character = pair.Key;
            if (count % 2 == 0)
            {
                leftPart.Append(new string(character, count / 2));
                rightPart.Insert(0, new string(character, count / 2));
            }
            else
            {
                leftPart.Append(new string(character, count / 2));
                rightPart.Insert(0, new string(character, count / 2));

                middleChar ??= pair.Key;
            }
        }

        StringBuilder fullPalindrome = new();
        fullPalindrome.Append(leftPart);
        if (middleChar != null)
        {
            fullPalindrome.Append(middleChar);
        }
        fullPalindrome.Append(rightPart);

        return fullPalindrome.ToString();
    }
}
