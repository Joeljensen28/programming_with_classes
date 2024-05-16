using System.IO;

public class Entry
{
    public string _dateResponse;
    public string _promptUsed;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"{_dateResponse} {_promptUsed}");
        Console.WriteLine(_entryText);
    }
}