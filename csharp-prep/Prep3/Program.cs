using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        do
        {
            //gets the magic number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int userGuess;
            int guessCount = 1;
            do
            {//gets the guess from user and converts it to int
            Console.WriteLine("Enter your guess:");
            string userGuessStr = Console.ReadLine();
            userGuess = int.Parse(userGuessStr);
            //checks if the number is greater than, equal to, or less than the magic number
            if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower.");
            }
            else if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher.");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {guessCount} guesses.");
                Console.WriteLine("Do you want to play again? (y/n)");
            }
            guessCount++;
            } while (userGuess != magicNumber); //loops through the code as long as the guess isn't correct
        
            playAgain = Console.ReadLine();
        } while (playAgain != "n");
    }
}