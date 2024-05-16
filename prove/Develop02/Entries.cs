using System.IO;

public class Entry
{
    public string _dateResponse;
    public string _promptUsed;
    public string _entryText;

    // public Entry(string prompt, string text, string date)
    // {
    //     _promptUsed = prompt;
    //     _entryText = text;
    //     _dateResponse = date;

    // }

    public void Display()
    {
        Console.WriteLine($"{_dateResponse} {_promptUsed}");
        Console.WriteLine(_entryText);
    }
}