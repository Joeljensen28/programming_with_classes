using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction newFract = new Fraction();
        Console.WriteLine("Empty class parameters");
        Console.WriteLine(newFract.GetDecimalValue());

        Fraction oneParam = new Fraction(5);
        Console.WriteLine("One clas parameter:");
        Console.WriteLine(oneParam.GetDecimalValue());

        Fraction twoParam = new Fraction(4, 9);
        Console.WriteLine("Two class parameters:");
        Console.WriteLine(twoParam.GetDecimalValue());
    }
}