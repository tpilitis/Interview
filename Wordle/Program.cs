using System;

namespace Wordle
{
    public class Program
    {
        static void Main(string[] args)
        {
            var maxAttempts = 3;
            var secretWord = "crown";

            Console.WriteLine("Guess the 5 length word?");
            Console.WriteLine($"You have {maxAttempts} attempts.");

            var wordie = new Word();

            var attempts = 0;
            while (attempts < maxAttempts)
            {
                attempts++;

                var guessWord = Console.ReadLine();
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
