public class Word
{
    // The word itself as a string
    private string _word;
    //Used to tell us if the word is underscores or not
    private bool _isHidden = false;
   
    // Constructor
    public Word(string word)
    {
        _word = word;
    }

    // Used to convert _word into underscores
    public string HideWord()
    {
        // Make a list of underscores for each letter in _word
        List<string> underscores = new();
        for (int i = 0; i < _word.Length; i++)
        {
            underscores.Add("_");
        }
        // Join the list into a singel string
        _word = String.Join("", underscores);
        // Update attribute so we know it's hidden
        _isHidden = true;
        return _word;
    }

    // Prints _word
    public void WriteWord()
    {
        Console.Write($"{_word} ");
    }

    // Gets the hidden status of the word
    public bool GetHiddenStatus()
    {
        return _isHidden;
    }
}