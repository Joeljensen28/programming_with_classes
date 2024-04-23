using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is youre first name?");
        string first_name = Console.ReadLine();
        
        Console.WriteLine("What is youre last name?");
        string last_name = Console.ReadLine();

        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");
    }
}