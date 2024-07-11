using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Are you a student or a teacher? (S/T)");
        string userType = Console.ReadLine();

        if (userType == "S")
        {
            Student student = new Student();
        }
        else if (userType == "T")
        {
            Teacher teacher = new Teacher();
        }
    }
}