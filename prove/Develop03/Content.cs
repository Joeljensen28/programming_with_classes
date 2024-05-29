public class Content
{
    // List of words in the scripture (empty until _content has been parsed)
    private List<Word> _words;
    // The actual content of the verse (i.e. "I Nephi having been born of goodly parents")
    private string _content;
    // The reference of the verse (i.e. 1 Nephi 1:1)
    private Reference _reference;

    // Constructor to establish the content and reference of the verse
    public Content(Reference reference, string content)
    {
        _content = content;
        _reference = reference;
    }

    // Gets the reference
    public Reference GetRef()
    {
        return _reference;
    }
    // Takes all the words in the content, converts them to Word objects, and then adds it to the _words list
    public void ParseContent()
    {
        // Make a new array of all the words in the content, split on the spaces
        string[] parts = _content.Split(" ");
        // Make a new list of words to give to _words later
        List<Word> newWords = new();
        // Loop through each part in the parts list
        foreach (string word in parts)
        {
            // Turn each part into a new Word object
            Word newWord = new Word(word);
            // Add it to the newWords list
            newWords.Add(newWord);
        }
        // Set words to the newWords list
        _words = newWords;
    }

    // Writes all of the words in the _words list
    public void WriteWordsList()
    {
        foreach (Word word in _words)
        {
            word.WriteWord();
        }
    }

    // Hides three random words
    public void HideWords()
    {
        // Create random class
        Random random = new();

        // Make a new list to store the indices of the words in _words
        List<int> indices = new();
        // Initialize the index counter outside the loop
        int i = 0;
        // Loop through each word in _words
        foreach (Word word in _words)
        {
            // Check if the word is hidden already
            if (word.GetHiddenStatus() == false)
            {
                // If not, then add its index to indices
                indices.Add(i);
                // Increment the index counter by 1
                i++;
            }
            else
            {
                // If so, then increment index counter by 1
                i++;
            }
        }

        // Choose three random ints within the length of indices
        int randInt1 = random.Next(indices.Count);
        int randInt2 = random.Next(indices.Count);
        int randInt3 = random.Next(indices.Count);

        // Use random ints to grab three unhidden indices
        int randIndex1 = indices[randInt1];
        int randIndex2 = indices[randInt2];
        int randIndex3 = indices[randInt3];

        // Pass them into _words as an index to randomly hide three words
        _words[randIndex1].HideWord();
        _words[randIndex2].HideWord();
        _words[randIndex3].HideWord();
    }

    // Checks if all the words in _words are hidden yet
    public bool CheckAllHidden()
    {
        // Set the "all hidden" status to true by default
        bool allHidden = true;
        // Loop through all the words in _words
        foreach (Word word in _words)
        {
            // Check if the word is hidden
            if (word.GetHiddenStatus() == false)
            {
                // If it is not hidden, allNotHidden is switched to false
                allHidden = false;
            }
            // Otherwise, allHidden continues to be true
        }
        // Return the final status of allHidden
        return allHidden;
    }
}