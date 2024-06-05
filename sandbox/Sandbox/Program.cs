using System;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Console.Write("_\b");
            Thread.Sleep(100);
            Console.Write("o\b");
            Thread.Sleep(100);
            Console.Write("O\b");
            Thread.Sleep(200);
            Console.Write("o\b");
            Thread.Sleep(100);
        }
    }
}