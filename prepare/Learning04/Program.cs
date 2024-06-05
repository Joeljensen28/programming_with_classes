using System;

class Program
{
    static void Main(string[] args)
    {
        WritingAssignment write = new WritingAssignment("Joel Jensen", "Writing", "Learning About Sigmas Ch. 2");
        Console.WriteLine(write.GetSummary());
        Console.Write(write.GetWritingInfo());
    }
}