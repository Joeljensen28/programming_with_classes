using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string userInput = Console.ReadLine();
        int pct = int.Parse(userInput);

        int lastDigit = pct % 10;

        string grade;
        if (pct >= 90)
        {
            grade = "A";
        }
        else if (pct >= 80)
        {
            grade = "B";
        }
        else if (pct >= 70)
        {
            grade = "C";
        }
        else if (pct >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        string plusOrMinus;
        if ((grade != "F" && grade != "A") && lastDigit >= 7)
        {
            plusOrMinus = "+";
        }
        else if (lastDigit <= 3 && grade != "F")
        {
            plusOrMinus = "-";
        }
        else
        {
            plusOrMinus = "";
        }

        Console.WriteLine($"Your grade is a(n) {plusOrMinus}{grade}");

        if (pct >= 70)
        {
            Console.Write("Congrats on passing the class!");
        }
        else
        {
            Console.Write("You fail broski!!!!");
        }
    }
}