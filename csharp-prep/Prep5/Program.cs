using System;
using System.Globalization;

class Program
{
    // prints a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // asks user for a name, and returns it in as a string
    static string PromptUserName()
    {
        Console.WriteLine("Enter your name here:");
        string userName = Console.ReadLine();
        return userName;
    }

    // asks for a number from a user and returns that number as an int
    static int PromptUserNumber()
    {
        Console.WriteLine("Enter your favorite number:");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);
        return number;
    }

    // takes one argument as an int and squares it
    static int SquareNumber(int num)
    {
        int squared = num * num;
        return squared;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }
}