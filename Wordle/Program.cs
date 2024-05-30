using System;

namespace Wordle
{
    public class Program
    {
        static void Main(string[] args)
        {
            var maxAttempts = 6;
            var secretWords = new[] { "apple", "crown", "dress", "sport", "coach" };

            var random = new Random();
            var wordIndex = random.Next(secretWords.Length - 1);
            var secretWord = secretWords[wordIndex];

            Console.WriteLine("Guess the 5 length word?");
            Console.WriteLine($"You have {maxAttempts} attempts.");

            var wordie = new Word();

            var attempts = 0;

            while (attempts < maxAttempts)
            {
                attempts++;

                var guessWord = Console.ReadLine();
                if (guessWord.Length != secretWord.Length)
                {
                    Console.WriteLine($"Please try with valid word. Max length: {secretWord.Length}. Press: 'Y' to continue.");
                    var answer = Console.ReadLine();
                    if (answer == "Y")
                    {
                        attempts--;
                        Console.WriteLine("Give me a word:");
                        guessWord = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                var resultWord = wordie.Match(guessWord, secretWord);

                Console.WriteLine(resultWord);

                if (wordie.IsFullMatch)
                {
                    Console.WriteLine($"You found the world from {attempts} attempt.");
                    break;
                }
                else
                {
                    Console.WriteLine($"Please try again. {maxAttempts - attempts} attempts to go :)");
                }
            }

            Console.ReadLine();
        }
    }
}
