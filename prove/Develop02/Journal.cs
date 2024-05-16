public class Journal
{
    // A list of the new daily entry from the user
    public List<Entry> _newEntries = new();

    // The name of the file the user wants to save the entries to
    public string _fileName;

    public void ShowEntries()
    {
        foreach (Entry entry in _newEntries)
        {
            entry.Display();
        }
    }

    // Writes user entries into .txt file
    public void SaveEntries()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (Entry entry in _newEntries)
            {
                outputFile.WriteLine($"{entry._dateResponse}||{entry._promptUsed}||{entry._entryText}");
            }
        }
    }

    // Loads a previous journal file into the entries list
    public void LoadEntries()
    {
        _newEntries.Clear();
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("||");

            string date  = parts[0];
            string prompt = parts[1];
            string text = parts[2];

            Entry oldEntry = new();
            oldEntry._dateResponse = date;
            oldEntry._entryText = text;
            oldEntry._promptUsed = prompt;

            _newEntries.Add(oldEntry);
        }
    }
}