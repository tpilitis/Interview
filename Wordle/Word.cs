using System.Linq;
using System.Text;

namespace Wordle
{
    public class Word
    {
        public bool IsFullMatch { get; private set; }

        public string Match(string inputWord, string secretWord)
        {
            if (inputWord.Equals(secretWord))
            {
                IsFullMatch = true;
                return string.Join("|", secretWord.ToCharArray());
            }

            var resultWord = new StringBuilder();
            var secretWorldChars = secretWord.ToCharArray();
            var inputWordChars = inputWord.ToCharArray();

            for (int i = 0; i < inputWord.Length; i++)
            {
                if (inputWordChars[i] == secretWorldChars[i])
                {
                    // matching position & letter
                    resultWord.Append($"{inputWordChars[i]}");
                }
                else
                {
                    if (secretWord.Contains(inputWordChars[i]))
                    {
                        // contains letter
                        resultWord.Append($"<{inputWordChars[i]}>");
                    }
                    else
                    {
                        // no match
                        resultWord.Append("*");
                    }
                }
            }

            resultWord.ToString();

            return resultWord.ToString();
        }
    }
}
