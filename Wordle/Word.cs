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
            var secretWorld = secretWord.ToArray();
            for (int i = 0; i < inputWord.Length; i++)
            {
                if (inputWord[i] == secretWorld[i])
                {
                    // matching position
                    resultWord.Append($"|{inputWord[i]}|");
                }
                else
                {
                    if (secretWord.Contains(inputWord[i]))
                    {
                        resultWord.Append($"<{inputWord[i]}>");
                    }
                    else
                    {
                        resultWord.Append(inputWord[i]);
                    }
                }
            }

            resultWord.ToString();

            return resultWord.ToString();
        }
    }
}
