using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        bool continuingLoop = true;
        Journal currentEntries = new();

        Console.WriteLine("Welcome to the Journal app!");
        while (continuingLoop == true)
        {
            Console.WriteLine("---------");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display your current entries");
            Console.WriteLine("3. Save your current journal");
            Console.WriteLine("4. Load a journal from a file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("---------");
            Console.WriteLine("Please choose what you want to do:");
            string userChoice = Console.ReadLine();
            
            if (userChoice == "1")
            {
                // Ask the user if they want a prompt
                Console.WriteLine("Would you like a prompt for inspiration? (Y/N)");
                string promptDecision = Console.ReadLine();
                // Convert the string to lowercase for checks in the WriteEntry function
                string decision = promptDecision.ToLower();
                // Pass the decision into the WriteEntry function which will then determine whether or not to give them a prompt
                Entry newEntry = WriteEntry(decision);
                currentEntries._newEntries.Add(newEntry);
            }

            else if (userChoice == "2")
            {
                // Display any current entries
                currentEntries.ShowEntries();
            }

            else if (userChoice == "3")
            {
                // Writes any current entries to a file
                Console.WriteLine("Enter the name of the file here:");
                currentEntries._fileName = Console.ReadLine();
                currentEntries.SaveEntries();
            }

            else if (userChoice == "4")
            {
                // Reads a given file in the folder and turns it into an Entry object and appends it to the list of current entries
                Console.WriteLine("WARNING: This will cause any unsaved entries to be lost");
                Console.WriteLine("Enter the name of the file here: ");
                currentEntries._fileName = Console.ReadLine();
                currentEntries.LoadEntries();
            }

            else if (userChoice == "5")
            {
                // Stops the program
                continuingLoop = false;
            }

            else
            {
                // In case the user doesn't enter 1-5
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
    // Write a new entry
    static Entry WriteEntry(string decision)
    {
        // Make new instance of Prompt class
        Prompt newPrompt = new();
        // If user chooses to have a prompt
        if (decision == "y")
        {
            // Set prompts attribute to the list of prompts
            newPrompt._prompts = new List<string> {
            "Who was the most interesting person I interacted with today?", 
            "What was the best part of my day?", 
            "How did I see the hand of the Lord in my life today?", 
            "What was the strongest emotion I felt today?", 
            "If I had one thing I could do over today, what would it be?",
            "What song was stuck in my head today?",
            "What superpower would have been most helpful for me today?"};
        }
        // If user chooses NOT to have a prompt
        else if (decision == "n")
        {
            // Set only prompt to "Freewriting"
            newPrompt._prompts = new List<string> {"Freewriting"};
        }

        // Get a random prompt and store it
        newPrompt._prompt = newPrompt.GetRandomPrompt();
        // Display the prompt
        newPrompt.DisplayPrompt(newPrompt._prompt);

        // Receive user's input and store it
        string newEntryText = Console.ReadLine();

        // Enter all the attributes into a new Entry instance
        Entry newCompleteEntry = new();
        newCompleteEntry._promptUsed = newPrompt._prompt;
        newCompleteEntry._dateResponse = DateTime.Now.ToString();
        newCompleteEntry._entryText = newEntryText;

        // Store instance of the Entry
        return newCompleteEntry;
    }
}

// This exceeded expectations by allowing the user to write an entry with or without a prompt, in case the user had an extraordinary day that didn't need a prompt to make it interesting. In this situation, it would replace the prompt attribute with a single string, "Freewrite".