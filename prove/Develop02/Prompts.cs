public class Prompt
{
    public List<string> _prompts = new();
    public string _prompt;

    public string GetRandomPrompt()
    {
    //Creates instance of the Random class
    Random random = new();
    // Generates a random int to use for the index on the prompts list
    int index = random.Next(_prompts.Count);

    // Uses randomIndex as the index on the list to get a random prompt
    string randomPrompt = _prompts[index];
    // Returns the index that was generated
    return randomPrompt;
    }
    
    public void DisplayPrompt(string prompt)
    {
        // Prints the prompt
        Console.WriteLine(prompt);
    }
}