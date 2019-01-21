using System;
using System.Collections.Generic;
using System.Text;

namespace WinterTest
{
    class Game
    {
        private int SecretNumber { get; set; }
        private int lowestNo = 0;
        private int highestNo = 100;
        public void MakeSecretNumber()
        {
            Random rand = new Random();
            SecretNumber = rand.Next(lowestNo, highestNo + 1);
        }
        public void RunGame(Player player)
        {
            bool guessed = false;
            int noOfGuesses = 0;
            int guess;
            MakeSecretNumber();
            Console.WriteLine($"Welcome {player.FullName}");
            Console.WriteLine($"Find my secret number between {lowestNo} and {highestNo}");
            while (guessed == false)
            {
                Console.Write($"Please enter your guess : ");
                int.TryParse(Console.ReadLine(), out guess);
                Console.WriteLine($"You entered : {guess}");
                noOfGuesses++;
                if (guess < SecretNumber)
                {
                    Console.WriteLine($"Your guess was smaller than my secret number");
                }
                else if (guess > SecretNumber)
                {
                    Console.WriteLine($"Your guess was larger than my secret number");
                }
                else
                {
                    Console.WriteLine($"Your guess was correct!");
                    Console.WriteLine($"You used {noOfGuesses} guesses");
                    player.RegisterScore(noOfGuesses);
                    guessed = true;
                }
            }
        }   
    }
}
