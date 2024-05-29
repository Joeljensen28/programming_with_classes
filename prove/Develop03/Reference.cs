public class Reference
{
    // Book of scripture
    private string _book;
    // Chapter of the book
    private int _chapter;
    // Starting verse
    private int _startVerse;
    // Ending verse
    private int _endVerse;

    // Constructor if they have multiple verses
    public Reference(string book, int chapter, int start, int end)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = start;
        _endVerse = end;
    }
    // Constructor if they only have one verse
    public Reference(string book, int chapter, int start)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = start;
        _endVerse = start;
    }

    // Writes the reference to the console
    public void DisplayRef()
    {
        // Checks if the start verse is the same as the end verse (if there are multiple verses or not)
        if (_startVerse != _endVerse)
        {
            // If false, write with the following format
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}-{_endVerse}");
        }
        else
        {
            // If true, write with the following format
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}");
        }
    }
}