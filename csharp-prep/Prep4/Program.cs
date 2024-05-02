using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new(); //makes a list of numbers

        string userInput;
        int number; //user input after being converted to int
        do
        {
            Console.WriteLine("Enter a number here (0 to stop):");
            userInput = Console.ReadLine();
            number = int.Parse(userInput); //stores a number from the user input

            numbers.Add(number); //adds all the numbers to the list
        } while (number != 0); //allows the user to press 0 to obtain the sum of all the numbers they entered

        int sum = numbers.Sum(); //gets the sum of the list

        int smallestPositive = 9999999;
        foreach (int num in numbers)
        {
            if (num < smallestPositive && num > 0) // checks if the number is smaller than the current smallest number, then checks if it is positive
            {
                smallestPositive = num;
            }
        }

        float average = (float)sum / numbers.Count; // calculates the average of the list

        int largestNumber = 0;
        foreach (int num in numbers)
        {
            if (num > largestNumber) // checks if the number is larger than the largest number so far
            {
                largestNumber = num;
            }
        }

        numbers.Sort(); // sorts the numbers from least to greatest

        Console.WriteLine($"The sum of the numbers is {sum}");
        Console.WriteLine($"The smallest positive number was {smallestPositive}");
        Console.WriteLine($"The average of the numbers is {average}");
        Console.WriteLine($"The largest number was {largestNumber}");
        Console.WriteLine("The sorted list of numbers is:");

        foreach (int num in numbers)
        {
            Console.WriteLine(num); // writes each number in the sorted list
        }
    }
}